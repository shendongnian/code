    <LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent" 
    android:orientation="vertical">
    <ListView
    android:layout_width="match_parent"
    android:layout_height="wrap_content" 
        android:id="@+id/listView1"/>
    <Button
    android:layout_width="match_parent"
    android:layout_height="wrap_content" 
        android:text="get files" android:id="@+id/button1"/>
    </LinearLayout>
     public class MainActivity : AppCompatActivity
    {
        private ListView listview1;
        private Button button1;
        private List<string> files;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            listview1 = FindViewById<ListView>(Resource.Id.listView1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            files = new List<string>();
            button1.Click += delegate
              {
                  getpermission();
                  //var targetdic = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/testfolder";
                  var targetdic = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "testfolder";
                  if(Directory.Exists(targetdic))
                  {
                      files = DirSearch(targetdic);
                      listview1.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, files);
                    
                      listview1.ItemClick += (s, e) =>
                      {
                          var t = files[e.Position];
                          Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Long).Show();
                      };
                  }
                  
              };
        }
        private void getpermission()
        {
            if (ActivityCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.ReadExternalStorage }, 1);
                return;
            }
        }
        
        private List<String> DirSearch(string sDir)
        {
            List<string> folders = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    folders.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    folders.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                
            }
            return folders;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
