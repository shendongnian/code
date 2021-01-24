    public sealed partial class EnvCoord : Page
    {
        string xcoord = string.Empty;
        string ycoord = string.Empty;
        string zcoord = string.Empty;
        private readonly _ViewModel view;
        public EnvCoord()
        {
            this.InitializeComponent();
            view = (App.Current as App).view;
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void EnvoyerCoord_Click(object sender, RoutedEventArgs e)
        {
            xcoord = CoordX.Text;
            ycoord = CoordY.Text;
            zcoord = CoordZ.Text;
            view.Bras.SendCoorGeom(xcoord, ycoord, zcoord);
            Frame.Navigate(typeof(MainPage));
        }
    }
   
