    var result = _dbContext.NotificationGroupUserType
        .Include(m => m.NotificationGroup)
        .Include(m => m.DeliveryType)
        .Where(m => m.UserTypeId == (int)userType)
        .AsEnumerable() // Following part is LINQ-to-Objects
        .Where(m => !notifications.Contains(new { m.NotificationGroupId, m.DeliveryTypeId }))
        .Select(m => new NotificationGroupUserType() {
            DeliveryType = m.DeliveryType,
            NotificationGroup = m.NotificationGroup
        })
        .ToList();
