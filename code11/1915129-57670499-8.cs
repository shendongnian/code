    [assembly: Dependency(typeof(iOSBrightnessService))]
    namespace App6.iOS
    {
        public class iOSBrightnessService : IBrightnessService
        {
            public float GetBrightness()
            {
                //throw new NotImplementedException();
                return (float)UIScreen.MainScreen.Brightness;
            }
    
            public void SetBrightness(float brightness)
            {
                //throw new NotImplementedException();
                UIScreen.MainScreen.Brightness = brightness;
            }
        }
    }
