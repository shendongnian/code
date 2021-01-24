     [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            // Create your application here
        }
        protected override void OnPause()
        {
            base.OnPause();
            //  SetContentView(Resource.Layout.activity_main);
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
     
    }
