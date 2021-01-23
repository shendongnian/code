    foreach (var item in recipients)
    {
        var notificationObj = new Notification
        {
             Sender = ClientUser.UserName,
             Recipient = item,
             ...
        }
        notificationObj.Add();
    }
