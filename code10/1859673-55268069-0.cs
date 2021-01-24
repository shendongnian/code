    public partial class DisplayMap : ContentPage
    {
        public static readonly BindableProperty LatitudeProperty = BindableProperty.Create(nameof(Latitude), typeof(double), typeof(DisplayMap), 0);
        public static readonly BindableProperty LongitudeProperty = BindableProperty.Create(nameof(Longitude), typeof(double), typeof(DisplayMap), 0);
        public double Latitude 
        {
            get { return (double)this.GetValue(LatitudeProperty); }
            set { this.SetValue(LatitudeProperty, value); }
        } 
        public double Longitude
        {
            get { return (double)this.GetValue(LongitudeProperty); }
            set { this.SetValue(LongitudeProperty, value); }
        } 
    
        public DisplayMap()
        {
    
            InitializeComponent();
            // ...
        }
