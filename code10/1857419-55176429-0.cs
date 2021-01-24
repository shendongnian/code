     if (!(CheckPermissionGranted(Manifest.Permission.AccessCoarseLocation) &&
                CheckPermissionGranted(Manifest.Permission.AccessFineLocation)))
            {
                RequestLocationPermission();
            }
            else
            {
                InitializeLocationManager();
            }
            InitPageWidgets();
