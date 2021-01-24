    public void SendNotification(UserInfo userToReceive)
    {
    	// Get the notification type; if it doesn't exist, create it
    	ModuleController mCtrl = new ModuleController();
    	var itemAddedNType = NotificationsController.Instance.GetNotificationType(Constants.NOTIFICATION_FILEDOWNLOAD);
    	if (itemAddedNType == null) 
    	{ 
    		AddNotificationType();
    		itemAddedNType = NotificationsController.Instance.GetNotificationType(Constants.NOTIFICATION_FILEDOWNLOAD);
    	}
    
       
    	if (itemAddedNType != null)
    	{
    		Notification msg = new Notification
    		{
    			NotificationTypeID = itemAddedNType.NotificationTypeId,
    			Subject = "A file is ready to download.",
    			Body = alertBody,
    			ExpirationDate = DateTime.MaxValue,
    			IncludeDismissAction = true,
    		};
    
    		List<UserInfo> sendUsers = new List<UserInfo>();
    		sendUsers.Add(userToReceive);
    
    		NotificationsController.Instance.SendNotification(msg, itemModule.PortalID, null, sendUsers);
    	}
    }
