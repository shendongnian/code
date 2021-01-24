    private async void _button_Clicked(object sender, EventArgs e)
        {
            webView.Source = "https://xamarin.swappsdev.net/";//"https://test.webrtc.org/";
            var status = PermissionStatus.Unknown;
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (status != PermissionStatus.Granted)
            {
                status = await Utils.CheckPermissions(Permission.Camera);
            }
        }
