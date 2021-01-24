    var selectedNotifications = _dbContext.UserNotificationTypeDeliveryChoice
                                .Include(m => m.NotificationGroup)
                                .Include(m => m.DeliveryType)
                                .Where(m => m.UserDefId == userDefId && m.UserTypeId == (int)userType)
                                .GroupBy( p => p.NotificationGroupId, p => p, 
                        (key,g) => new { 
                             NotificationId = key, 
                             Name = g.First().Name, 
                             DeliveryTypes = g.Select(x => x.DeliveryTypes)
                                   }););
