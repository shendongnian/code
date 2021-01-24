    public class MainActivity : AppCompatActivity,ScreenStateListener
    {
       ScreenListener mScreenListener;
       protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            mScreenListener = new ScreenListener(this);
        }
       protected override void OnDestroy()
        {
            base.OnDestroy();
            mScreenListener.unregisterListener();
        }
       protected override void OnResume()
        {
            base.OnResume();
            mScreenListener.begin(this);
    
        }
       public void onScreenOn()
        {
            Console.WriteLine("onScreenOn");
        }
       public void onScreenOff()
        {
            Console.WriteLine("onScreenOff");
        }
       public void onUserPresent()
        {
            Console.WriteLine("onUserPresent");
        }
    
    }
