using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {//remove notification
        AndroidNotificationCenter.CancelAllDisplayedNotifications();




        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Remider  notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
// ad the notification that is going to be send
        var notification = new AndroidNotification();
        notification.Title = "Hey! comeback";
        notification.Text = "Start to play Games";
        notification.FireTime = System.DateTime.Now.AddSeconds(15);
//send the notification
  var id =      AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
