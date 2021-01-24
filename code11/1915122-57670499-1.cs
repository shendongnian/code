    [assembly: Xamarin.Forms.Dependency(typeof(AndroidBrightnessService))]
    namespace App6.Droid
    {
        public class AndroidBrightnessService : IBrightnessService
        {
            [Obsolete]
            public float GetBrightness()
            {
                //throw new NotImplementedException();
                var window = ((Activity)Forms.Context).Window;
                //var window = CrossCurrentActivity.Current.Activity.Window;
                var attributesWindow = new WindowManagerLayoutParams();
    
                attributesWindow.CopyFrom(window.Attributes);
    
                return attributesWindow.ScreenBrightness;
            }
    
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
