        foreach(UILocalNotification sNote in UIApplication.SharedApplication.ScheduledLocalNotifications)
        {
            if(sNote.FireDate == DateTime.Now)
            {
                //Cancel the Notification'
                UIApplication.SharedApplication.CancelLocalNotification (sNote);
            }
        }
