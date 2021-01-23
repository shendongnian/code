    public class DPGroup : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty MyProperty1Property =
            DependencyProperty.RegisterAttached(
            "MyProperty1",
            typeof(int),
            typeof(DPGroup),
            new PropertyMetadata(1, OnPropertyChanged));
        public int MyProperty1
        {
            get { return (int)GetValue(MyProperty1Property); }
            set { SetValue(MyProperty1Property, value); }
        }   
        // static method invoked when MyProperty1 has changed value
        static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DPGroup g = d as DPGroup;
            if (g != null)
            {
                g.MyProperty1 = (int)e.NewValue;
                // invoking event handler, to notify parent class about changed value of DP
                if (g.PropertyChanged != null) g.PropertyChanged(g, null);                
            }
        }
        // event handler, for use in parent class
        public event PropertyChangedEventHandler PropertyChanged;             
    }
