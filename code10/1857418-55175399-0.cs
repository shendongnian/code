    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainLoaderActivity : AppCompatActivity {
        private const string LOG_TAG = "CAMERA2_LOG";        
        private const int PERMISSION_REQUEST_CODE_CAMERA_USAGE = 4500;  // Arbitrary number to identify our permissions required for camera app usage
        private Button btnLoadCameraActivity;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_loader);
            btnLoadCameraActivity = FindViewById<Button>(Resource.Id.btnLoadCameraActivity);
            btnLoadCameraActivity.Click += btnLoadCameraActivity_Click;
        }
        private void btnLoadCameraActivity_Click(object sender, EventArgs e) {
            // Using the camera on Android 6.0 and later requires a run-time permissions granting by the user.
            // So, check to see if user manually enabled in Settings, or previously was prompted in this app and was granted access.  If not, we'll prompt them...
            if (CheckSelfPermission(Android.Manifest.Permission.Camera) == Permission.Granted && 
                CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage) == Permission.Granted) {
                // We have both permissions necessary to run the Camera interface...
                StartActivity(typeof(CameraActivity));
                return;
            }
            // If we get here, at least one of the required permissions hasn't been approved, so find out which one and request accordingly...
            var listPermissions = new System.Collections.Generic.List<string>();
            // Build array of permissions needed for Camera usage
            if (CheckSelfPermission(Android.Manifest.Permission.Camera) != Permission.Granted) {
                Log.Warn(LOG_TAG, "CheckSelfPermission(Camera) not yet granted - will prompt user for permission");
                listPermissions.Add(Android.Manifest.Permission.Camera);
            }
            if (CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted) {
                Log.Warn(LOG_TAG, "CheckSelfPermission(WriteExternalStorage) not yet granted - will prompt user for permission");
                listPermissions.Add(Android.Manifest.Permission.WriteExternalStorage);
            }
            // Make the request with the permissions needed...and then check OnRequestPermissionsResult() for the results
            RequestPermissions(listPermissions.ToArray(), PERMISSION_REQUEST_CODE_CAMERA_USAGE);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
            Log.Info(LOG_TAG, $"OnRequestPermissionsResult(requestCode={requestCode} - Permissions Count={permissions.Length} - GrantResults Count={grantResults.Length})");
            switch (requestCode) {
                // To use the camera, the user must grant privs to the Camera as well as writing to external storage, so this case checks both
                case PERMISSION_REQUEST_CODE_CAMERA_USAGE: {                    
                    for (var i = 0; i < permissions.Length; i++) {
                        Log.Info(LOG_TAG, $"Checking permission for {permissions[i]}...");
                        if (grantResults[i] != Permission.Granted) {
                            Log.Info(LOG_TAG, $"Permission Denied for {permissions[i]}!");
                            Toast.MakeText(this, "You must approve all permissions prompted to use the camera.", ToastLength.Long).Show();
                            return;
                        }
                        Log.Info(LOG_TAG, $"Permission Granted for {permissions[i]}.");
                    }
                    // If we get here then all the permissions we requested were approved and we can now load the Camera interface
                    StartActivity(typeof(CameraActivity));
                    break;
                }
            }
        }
    }
