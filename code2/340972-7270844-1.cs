    namespace SilverlightApplication1
    {
        public class MyControl : Control
        {
            public MyControl()
            {
                this.DefaultStyleKey = typeof(MyControl);
            }
    
            public static readonly DependencyProperty ValueProperty =
      DependencyProperty.Register("Value",
      typeof(double),
      typeof(MyControl),
      new PropertyMetadata(0d, OnValueChanged));
    
            public double Value
            {
                get { return (double)base.GetValue(ValueProperty); }
                set { base.SetValue(ValueProperty, value); }
            }
    
            private static void OnValueChanged(DependencyObject source,
                                               DependencyPropertyChangedEventArgs e)
            {
                MyControl myControl = (MyControl)source;
                myControl.OnValueChanged((double)e.OldValue, (double)e.NewValue);
            }
    
            protected virtual void OnValueChanged(double oldValue, double newValue)
            {
                double coercedValue = CoerceValue(newValue);
                if (coercedValue != newValue)
                {
                    this.Value = coercedValue;
                }
            }
    
            private double CoerceValue(double value)
            {
                double limit = 7;
                if (value > limit)
                {
                    return limit;
                }
                return value;
            }
    
        }
    }
