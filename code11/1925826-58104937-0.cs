        [assembly: UsesPermission(Name = Android.Manifest.Permission.ReadExternalStorage)]
        [assembly: UsesPermission(Name = Android.Manifest.Permission.WriteExternalStorage)]
        ...
        ...
        ...
        public static readonly int PickImageActivityId = 91;
        public static readonly int RequestPermission_WriteExternalStorage = 92;
        static string[] Permissions = {
            Android.Manifest.Permission.ReadExternalStorage,
            Android.Manifest.Permission.WriteExternalStorage
        };
        ...
        if (FragmentController.Activity.CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage) != (int)Android.Content.PM.Permission.Granted)
            {
                FragmentController.RequestPermissions(Permissions, RequestPermission_WriteExternalStorage);
            }
            else
            {
                //already granted?
            }
        ...
        ...
