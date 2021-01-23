    public class AnimatedDoubleValue : UIElement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        private double _value_cache; // this stores the current animated value!
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                if (_value_cache == value)
                    return;
                _value_cache = value;
                SetValue(ValueProperty, value);
                FirePropertyChanged("Value");
            }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(AnimatedDoubleValue), new UIPropertyMetadata(0.0, ValuePropertyChanged));
        private static void ValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var self = (AnimatedDoubleValue)sender;
            var value = (double)e.NewValue;
            self.UpdateValue(value);
        }
        private void UpdateValue(double value)
        {
            _value_cache = value;
            FirePropertyChanged("Value");
        }
    }
