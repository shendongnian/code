    try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await DisplayAlert("Need camera", "Gunna need that camera", "OK");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                    status = results[Permission.Camera];
                }
                if (status == PermissionStatus.Granted)
                {
                     Console.WriteLine("camera access");
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("camera Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                LabelGeolocation.Text = "Error: " + ex;
            }
