    public class CurrentDevice
    {
        protected static CurrentDevice Instance;
        double width;
        double height;
        static CurrentDevice()
        {
            Instance = new CurrentDevice();
        }
        protected CurrentDevice()
        {
        }
        public static bool IsOrientationPortrait()
        {
            return Instance.height > Instance.width;
        }
        public static void SetSize(double width, double height)
        {
            Instance.width = width;
            Instance.height = height;
        }
    }
