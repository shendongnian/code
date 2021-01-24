     public async void CheckMyPermissionAsync()
            {
    
                var permissionsStartList = new List<Permission>()
                {
                    Permission.Storage
                };
    
                var permissionsNeededList = new List<Permission>();
                try
                {
                    foreach (var permission in permissionsStartList)
                    {
                        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
                        if (status != PermissionStatus.Granted)
                        {
                            permissionsNeededList.Add(permission);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
    
                var results = await CrossPermissions.Current.RequestPermissionsAsync(permissionsNeededList.ToArray());
    
                //Check the persimmison again
                var storeagePermission = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
    
                if (storeagePermission == PermissionStatus.Granted)
                {
                    //Download file here
                    DownloadFile("http://www.dada-data.net/uploads/image/hausmann_abcd.jpg", "XF_Downloads");
                }
                else {
    
                    Console.WriteLine("No permissions");
                }         
            }
