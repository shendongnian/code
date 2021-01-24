    public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
                         Android.Content.PM.Permission[] grantResults)
        {
            Log.Info(Tag, "onRequestPermissionResult");
            if (requestCode == RequestPermissionsRequestCode)
            {
                if (grantResults.Length <= 0)
                {
                    // If user interaction was interrupted, the permission request is cancelled and you
                    // receive empty arrays.
                    Log.Info(Tag, "User interaction was cancelled.");
                }
                else if (grantResults[0] == PermissionChecker.PermissionGranted)
                {
                    // Permission was granted.
                    Service.RequestLocationUpdates();
                }
                else
                {
                    // Permission denied.
                    SetButtonsState(false);
                    Toast.MakeText(this, "Permission Denied", ToastLength.Long).Show();
                }
            }
        }
