    public abstract class FlatScreenTV
    {
        public FlatScreenTV()
        {
            CustomProperties = new Dictionary<string,object>();
        }
	
        public Dictionary<string,object> CustomProperties { get; private set; }
        public string Size { get; set; }
        public string ScreenType { get; set; }
    }
    public class PhillipsFlatScreenTV : FlatScreenTV
    {
        public PhillipsFlatScreenTV()
        {
            BackLightIntensity = 0;
        }
	
        // Specific to Phillips TVs. Controls the backlight intensity of the LCD screen.
        public double BackLightIntensity 
        { 
            get { return (double)CustomProperties["BackLightIntensity"]; }
            set { CustomProperties["BackLightIntensity"] = value; }
        }
    }
    public class SamsungFlatScreenTV : FlatScreenTV
    {
        public SamsungFlatScreenTV()
        {
            AutoShutdownTime = 0;
        }
        // Specific to Samsung TVs. Controls the time until the TV automatically turns off.
        public int AutoShutdownTime 
        {
            get { return (int)CustomProperties["AutoShutdownTime"]; }
            set { CustomProperties["AutoShutdownTime"] = value; }
        }
    }
