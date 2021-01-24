    var notification = new TemplateNotification(new Dictionary<string, string>()
    {
     {"APNS_Expiry", DateTime.UtcNow.AddMinutes(10).ToString("o") }, //Timestamp
                            {"body", NotificationText},
                            {"payload", NotificationText},
                            {"deeplinking", payload},
                        }); 
                var Responsehub = hub.SendNotificationAsync(notification);
