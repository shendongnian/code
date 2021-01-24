    public partial class MainPage : ContentPage
    {
        TK.CustomMap.TKCustomMap map;
        TK.CustomMap.Position position;
        public MainPage()
        {
            InitializeComponent();
            //37,-122
            double lit = 37;// double.Parse(Center.CenterLocationX);
            double longt = -122;// double.Parse(Center.CenterLocationY);
            position = new TK.CustomMap.Position(lit, longt);
            TK.CustomMap.MapSpan span = TK.CustomMap.MapSpan.FromCenterAndRadius(position, TK.CustomMap.Distance.FromMiles(0.5));
            map = new TK.CustomMap.TKCustomMap(span);
            map.IsShowingUser = true;
            map.MapType = TK.CustomMap.MapType.Street;
            map.MapClicked += OnMapClicked;
            Content = map;
        }
        private void OnMapClicked(object sender, TKGenericEventArgs<Position> e)
        {
            TK.CustomMap.TKCustomMapPin pin = new TK.CustomMap.TKCustomMapPin()
            {
                //Address = "Test",
                //Label = "Test",
                Position = position
            ,
                IsDraggable = true
                //Type = PinType.SearchResult
            };
            
            map.Pins = new List<TK.CustomMap.TKCustomMapPin>() { pin };
            
        }
    }   
