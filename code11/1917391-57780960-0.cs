      private async void Btn1_Click(object sender, System.EventArgs e)
        {
            var status = PermissionStatus.Unknown;
            try
            {
                 status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        Console.WriteLine("Need location", "Gunna need that location", "OK");
                        
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = results[Permission.Location];
                }
                if (status == PermissionStatus.Granted)
                {
                   //do something about location.
                }
                else if (status != PermissionStatus.Unknown)
                {
                    Console.WriteLine("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
