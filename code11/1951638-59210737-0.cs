    var result = currentNotifications.Select(x => new NotificationListViewModel
    {
        DeliveryType = new DeliveryTypeViewModel
        {
            DeliveryTypeId = x.DeliveryType.DeliveryTypeId,
            Name = x.DeliveryType.Name
        },
        NotificationGroup = new NotificationGroupViewModel
        {
            NotificationGroupId = x.NotificationGroup.NotificationGroupId,
            Name = x.NotificationGroup.Name
        }
    });
