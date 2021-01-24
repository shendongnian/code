    [assembly: Xamarin.Forms.Dependency(typeof(AndroidBrightnessService))]
    namespace App6.Droid
    {
        public class AndroidBrightnessService : IBrightnessService
        {
            [Obsolete]
            public float GetBrightness()
            {
                //throw new NotImplementedException();
                //var window = ((Activity)Forms.Context).Window;
                
                //var attributesWindow = new WindowManagerLayoutParams();
    
                //attributesWindow.CopyFrom(window.Attributes);
                
                var brightness = Android.Provider.Settings.System.GetInt(MainActivity.thisMainActivity.ContentResolver, Android.Provider.Settings.System.ScreenBrightness);
                //MainActivity.thisMainActivity is a isntance from activity
                //The returned brightness is an int type value between 0 and 255.
                return brightness;
            }
            [Obsolete]
            public void SetBrightness(float brightness)
            {
                //throw new NotImplementedException();
                var window = ((Activity)Forms.Context).Window;
                //var window = CrossCurrentActivity.Current.Activity.Window;
                var attributesWindow = new WindowManagerLayoutParams();
    
                attributesWindow.CopyFrom(window.Attributes);
                attributesWindow.ScreenBrightness = brightness;
    
                window.Attributes = attributesWindow;
            }
        }
    }
