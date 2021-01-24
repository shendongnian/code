private async Task ChoosePhoto()
{
	var permission = await CheckCameraRollPermission();
	if (permission == PermissionStatus.Granted)
	{
		await CrossMedia.Current.Initialize();
		// Show image picker dialog
		var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
		{
			ModalPresentationStyle = Plugin.Media.Abstractions.MediaPickerModalPresentationStyle.OverFullScreen
		});
		if (file != null)
		{
			// Image has been selected
			using (var stream = file.GetStream())
			{
				using (var memoryStream = new System.IO.MemoryStream())
				{
					stream.CopyTo(memoryStream);
					var fileBytes = memoryStream.ToArray();
					
					// DO WHATEVER YOU WANT TO DO WITH THE SELECTED IMAGE AT THIS POINT
				}
			}
		}
	}
}
private async Task<PermissionStatus> CheckCameraRollPermission()
{
	// Check permission for image library access
	var permission = await PermissionsImplementation.Current.CheckPermissionStatusAsync(Permission.Photos);
	if (permission != PermissionStatus.Granted)
	{
		// Permission has not been granted -> if permission has been requested before and the user did not grant it, show message and return the permission
		var message = "";
		switch (permission)
		{
			case PermissionStatus.Denied:
			case PermissionStatus.Restricted:
				message = "Unfortunately, you did not grant permission to access the camera roll. If you want to change this, you can do so in the system settings of your device.";
				break;
			default:
				break;
		}
		if (!string.IsNullOrEmpty(message))
		{
			// Message available -> Display alert and return the permission
			var alert = UIAlertController.Create("Permission not granted", message, UIAlertControllerStyle.Alert);
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			PresentViewController(alert, true, null);
			return permission;
		}
		// In all other cases, request the permission
		await PermissionsImplementation.Current.RequestPermissionsAsync(Permission.Photos);
		// Check for permission one more time and return it
		permission = await PermissionsImplementation.Current.CheckPermissionStatusAsync(Permission.Photos);
	}
	return permission;
}
