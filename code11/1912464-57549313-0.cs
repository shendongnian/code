    public class MainActivity : FragmentActivity
    {
       //it is very important to instantiate with static
       public static Window _window = null; // do this directly inside MainActivity
        protected override void OnCreate(Bundle savedInstanceState)
        {
           //bunch of code here
           
          _window = this.Window; //we can only assign Window inside 
                   //OnCreate??  I tried to do it in another custom method
                    //but it would always return null
        }
        public void MyCustomWindowMethod()
        {
             //I was previously trying to assign window inside this method
             //that doesn't work.
             //this var hides the statusbar on android
             var _winflag1 = WindowManagerFlags.Fullscreen;
             //since we assigned window in OnCreate, now _window isn't null
             _window.AddFlags(_winflag1); 
        }
    }
