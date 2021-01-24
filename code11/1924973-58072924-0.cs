    try
     {
	   var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
	   if (status != PermissionStatus.Granted)
	    {
		  if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
		   {
			await DisplayAlert("Need location", "Gunna need that location", "OK");
		   }
		   status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
	    }
	  if (status == PermissionStatus.Granted)
	   {
		// do something you want
	   }
	  else if (status != PermissionStatus.Unknown)
	   {
		//location denied
	   }
    }
    catch (Exception ex)
     {
     //Something went wrong
     }
