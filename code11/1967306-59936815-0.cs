               if( !await CheckForStoragePermissions() ) 
                {
                    DialogService.Alert("Invalid Permission", "User declined permission for this action");
                    return;
                }
        private async Task<bool> CheckForStoragePermissions()
        {
            PermissionStatus storagePermissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (storagePermissionStatus != PermissionStatus.Granted)
            {
                Dictionary<Permission, PermissionStatus> storagePermissionResult = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                if (storagePermissionResult.ContainsKey(Permission.Storage))
                {
                    storagePermissionStatus = storagePermissionResult[Permission.Storage];
                }
            }
            return storagePermissionStatus == PermissionStatus.Granted;
        }
