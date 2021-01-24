    private bool GetClientNotifications(int clientId, IList<ClientNotification> clientNotifications)
    {
    	IList<string> clientNotificationList = null;
    	var clientNotificationsExists = clientNotifications?
    		.Select(x => new { x.Name, x.notificationId	}).ToList();
    	if (clientNotificationsExists?.Count > 0)
    	{
    		var notificationIds = clientNotificationsExists.Select(x => x.notificationId).ToArray();
    		clientNotificationList = this._clientNotificationRepository?
    			.FindBy(x => x.clientId == clientId && notificationIds.Contains(x.notificationId));
    	}
    	return clientNotificationList;
    }
