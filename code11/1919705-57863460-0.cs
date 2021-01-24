    if(submissionOwnerId != currentUser.Id)
    {
      notification.ToUsers = notification.ToUsers
                             .Append(new NotificationToUser { IsRead = false, UserId = submissionOwnerId })
                             .ToList()
    }else//for the situation you do not need to append new NotificationToUser 
    {
     notification.ToUsers = notification.ToUsers.ToList()
    }
    _context.Notifications.Add(notification);
    _context.SaveChanges();
    
