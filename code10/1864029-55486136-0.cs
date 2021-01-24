    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        Button button1;
        ImageView imageView1;
        View layout;
        static readonly int REQUEST_CAMERA_WriteExternalStorage = 0;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            layout = FindViewById<RelativeLayout>(Resource.Id.sample_main_layout);
            button1 = FindViewById<Button>(Resource.Id.button1);
            imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);
            button1.Click += (o, e) =>
            {
                CheckPermission();
            };
        }
        
      
        public  void CheckPermission()
        {
            if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted)&& (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted))
            {
                // Camera and store permission has  been granted
                ShowCamera();
            }
            else
            {
                // Camera and store permission has not been granted
                RequestPermission();
             
            }
        }
        private void RequestPermission()
        {
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera, Manifest.Permission.WriteExternalStorage }, REQUEST_CAMERA_WriteExternalStorage);
           
        }
      
        //get result of persmissions
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == REQUEST_CAMERA_WriteExternalStorage)
            {
             
                if ( PermissionUtil.VerifyPermissions(grantResults))
                {
                    // All required permissions have been granted, display Camera.
                 
                    ShowCamera();
                }
                else
                {
                    // permissions did not grant, push up a snackbar to notificate USERS
                    Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
        private void ShowCamera()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap=null;
            //If user did not take a photeo , he will get result of bitmap, it is null
            try {
                 bitmap = (Bitmap)data.Extras.Get("data");
            } catch(Exception e)
            {
                Log.Error("TakePhotoDemo1", e.Message);
                Toast.MakeText(this, "You did not take a photo", ToastLength.Short).Show();
            }
           
            if (bitmap != null)
            {
                MediaStore.Images.Media.InsertImage(ContentResolver, bitmap, "screen", "shot");
                imageView1.SetImageBitmap(bitmap);
            }
            else
            {
                Toast.MakeText(this, "You did not take a photo", ToastLength.Short).Show();
            }
        }
    }
