    public partial class NewTravelPage : ContentPage {
        public NewTravelPage() {
            InitializeComponent();
            appearing += onAppearing;
        }
        
        protected override void OnAppearing() {
            appearing(this, EventArgs.Empty);
        }
        
        event EventHandler appearing = delegate { };
        
        private async void onAppearing(object sender, EventArgs args) {
            try {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                var vanues = await VenueLogic.getVenues(position.Latitude, position.Longitude);
                venueListView.ItemsSource = vanues;
            } catch( Exception ex) {
                //handler error (Log?)
            }
        }
    }
