    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;
            // Rotation (0, 90, 180, 270)
            var rotation = mainDisplayInfo.Rotation;
            // Width (in pixels)
            var width = mainDisplayInfo.Width;
            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            // Screen density
            var density = mainDisplayInfo.Density;
        }
    }
    public struct Constant
    {
        public static double ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        public static double ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
    }
