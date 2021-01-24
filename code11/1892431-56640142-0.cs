    public void AddUserNotification(Notification notification, IList<int> tagIds) 
    {
        var usersToAddTheNotificationTo = DbContext.Users
            .Where(x => x.Tags.Any(t => tagIds.Contains(t.TagId)).ToList();
    
        foreach(var user in usersToAddTheNotificationTo) 
        {
              user.Notifications.Add(notification);
        }
    }
