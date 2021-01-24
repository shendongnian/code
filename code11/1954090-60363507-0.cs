    //.Where(m => !selectedNotificationsMatchingIds
    //           .Contains(new { m.NotificationGroup.NotificationGroupId, 
    //                                            m.DeliveryType.DeliveryTypeId }))
        
    .Where(m => !selectedNotificationsMatchingIds
            .Any(c => c.NotificationGroup.NotificationGroupId == m.NotificationGroupId
                    && c.DeliveryTypeId == m.DeliveryType.DeliveryTypeId))
