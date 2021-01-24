    public partial class MainPage : ContentPage
    {
        private Map myMap;
        public MainPage()
        {
            InitializeComponent();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude),
                Distance.FromMiles(0.5)));
            myMap.IsShowingUser = true;
            myMap.VerticalOptions = LayoutOptions.FillAndExpand;
            var position1 = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Current Position",
                Address = ""
            };
            myMap.Pins.Add(pin1);
        }
    }
