    var notifications = selectedNotificationsByUser
        .Select(n => new { n.NotificationGroupId, n.DeliveryTypeId })
        .Distinct()
        .ToList();
    var result = _dbContext.NotificationGroupUserType
        .Include(m => m.NotificationGroup)
        .Include(m => m.DeliveryType)
        .Where(m => m.UserTypeId == (int)userType &&
            !notifications.Contains(new { m.NotificationGroupId, m.DeliveryTypeId }))
        .Select(m => new NotificationGroupUserType() {
            DeliveryType = m.DeliveryType,
            NotificationGroup = m.NotificationGroup
        })
        .ToList();
