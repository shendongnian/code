    [assembly: Dependency(typeof(DeviceService))]
      class DeviceService : IDeviceService
      {
        public bool GetApplicationNotificationSettings()
         {
         var settings = UIApplication.SharedApplication.CurrentUserNotificationSettings.Types;
                return settings != UIUserNotificationType.None;
         }
       } 
