       [assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
     namespace App3.Droid
     {
       [Activity(Label = "App3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,IClick
    {
        public string GetContent()
        {
            string content="";
            AssetManager asset = Application.Context.Assets;
            using (StreamReader sr = new StreamReader(asset.Open("note.xml")))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
      }
     }
