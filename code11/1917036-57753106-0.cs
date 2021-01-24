    async void RequestPermissionAsync()
    {
      var status = await CrossPermissions.Current.CheckPermissionStatusAsync<PhonePermission>();
      if (status != PermissionStatus.Granted)
      {
        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Phone))
        {
          // has no permission
        }
        status = await CrossPermissions.Current.RequestPermissionAsync<PhonePermission>();
       }
       if (status == PermissionStatus.Granted)
       {
         //Query permission
         StateListener phoneStateListener = new StateListener();
         TelephonyManager telephonyManager = (TelephonyManager)GetSystemService(TelephonyService);
         telephonyManager.Listen(phoneStateListener, PhoneStateListenerFlags.CallState);
        }
        else if (status != PermissionStatus.Unknown)
        {
                //permission denied
        }
    }
