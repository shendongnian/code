    public class ClockControl: UserControl
        {
            public static readonly DependencyProperty CityProperty = DependencyProperty.Register
                (
                     "City", 
                     typeof(string), 
                     typeof(ClockControl), 
                     new PropertyMetadata(string.Empty)
                );
    
            public string City
            {
                get { return (string)GetValue(CityProperty); }
                set { SetValue(CityProperty, value); }
            }
    
            public ClockControl()
            {
                InitializeComponent();
            }
            //..........
    }
