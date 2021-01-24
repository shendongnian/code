MainPage.xaml.cs
 
          public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CameraImage.Source = "CameraImage.png";
          
            MessagingCenter.Subscribe<App, string>(App.Current, "OpenPage", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    CameraImage.Source = arg;
                });
            });
        }   
    }
     
MainActivity.cs
           public static class App_test
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }
    [Activity(Label = "InterceptButton", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            LoadApplication(new App());
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {
                Toast.MakeText(this, "OnKeyUp-VolumeDown", ToastLength.Short).Show();
               
                return true;
            }
            if (keyCode == Keycode.VolumeUp)
            {
              //  Toast.MakeText(this, "OnKeyUp-VolumeUp", ToastLength.Short).Show();
                return true;
            }
           
            return base.OnKeyUp(keyCode, e);
        }
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {
                Toast.MakeText(this, "OnKeyDown-VolumeDown", ToastLength.Short).Show();
                return true;
            }
            if (keyCode == Keycode.VolumeUp)
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                   App_test._file = new File(App_test._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
                   intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App_test._file));
                StartActivityForResult(intent, 0);
                Toast.MakeText(this, "OnKeyDown-VolumeUp", ToastLength.Short).Show();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App_test._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
         
            App_test.bitmap = App_test._file.Path.LoadAndResizeBitmap(100, 100);
           string path= App_test._file.Path;
            if (App_test.bitmap != null)
            {
                MessagingCenter.Send<App, string>(App.Current as App, "OpenPage", path);
                App_test.bitmap = null;
            }
            GC.Collect();
        }
        private void CreateDirectoryForPictures()
        {
            App_test._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App_test._dir.Exists())
            {
                App_test._dir.Mkdirs();
            }
        }
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
    }
