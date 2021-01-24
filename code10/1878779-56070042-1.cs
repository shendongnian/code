        [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
           var Fragment1 = new Fragment1();
           FragmentManager.BeginTransaction()
                        .Add(Android.Resource.Id.Content, Fragment1)
                        .Commit();
        }
     
    }
