    [Activity(MainLauncher = true, NoHistory = true)]
    public class Splashscreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView (Resource.Layout.splashscreen);
			new Thread (new ThreadStart (() =>
											{
												//Load something here ...
												Thread.Sleep(1500);
												Intent main = new Intent (this, typeof(MainActivity));
												this.StartActivity (main);
												this.Finish ();
											})).Start ();
        }
    }
