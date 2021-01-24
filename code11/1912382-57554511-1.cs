    public void UpdateProgress()
            {​
                // Construct a NotificationData object;​
                string tag = "Myplaylist";​
                string group = "playing";​
    ​
                // Create NotificationData and make sure the sequence number is incremented​
                // since last update, or assign 0 for updating regardless of order​
                var data = new NotificationData​
                {​
                    SequenceNumber = 0​
                };​
    
                data.Values["progressValue"] = "0.7";​
                data.Values["progressValueString"] = "My first song";​
    ​
                // Update the existing notification's data by using tag/group​
                ToastNotificationManager.CreateToastNotifier().Update(data, tag, group);​
            }
