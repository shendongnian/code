    public void AddNotificationType()
    {
    	var actions = new List<NotificationTypeAction>();
    	var deskModuleId = DesktopModuleController.GetDesktopModuleByFriendlyName(Constants.DESKTOPMODULE_FRIENDLYNAME).DesktopModuleID;
    
    	var objNotificationType = new NotificationType
    	{
    		Name = Constants.NOTIFICATION_FILEDOWNLOAD,
    		Description = "Get File Attachment",
    		DesktopModuleId = deskModuleId
    	};
    
    	if (NotificationsController.Instance.GetNotificationType(objNotificationType.Name) == null)
    	{
    		var objAction = new NotificationTypeAction
    		{
    			NameResourceKey = "DownloadAttachment",
    			DescriptionResourceKey = "DownloadAttachment_Desc",
    			APICall = "DesktopModules/MyCustomModule/API/mynotification/downloadfile",
    			Order = 1
    		};
    		actions.Add(objAction);
    
    		NotificationsController.Instance.CreateNotificationType(objNotificationType);
    		NotificationsController.Instance.SetNotificationTypeActions(actions, objNotificationType.NotificationTypeId);
    	}
    }
