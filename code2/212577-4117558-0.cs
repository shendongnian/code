    public class Data : DependencyObject
    {
        public static readonly DependencyProperty AProperty = DependencyProperty.Register("A", typeof(Boolean), typeof(Data), new PropertyMetadata(false,HandleValueChanged));
        public static readonly DependencyProperty BProperty = DependencyProperty.Register("B", typeof(Boolean), typeof(Data), new PropertyMetadata(false, HandleValueChanged));
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result",typeof (Boolean), typeof (Data));
        private static void HandleValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(ResultProperty, ((Data)d).Result);
            Debug.WriteLine("Value change");
        }
        public bool Result
        {
            get { return A & B; }
        }
        public bool A
        {
            get { return (bool) GetValue(AProperty); }
            set
            {
                if ( A != value )
                    SetValue(AProperty, value);
            }
        }
        public bool B
        {
            get
            {
                return (bool) GetValue(BProperty);
            }
            set
            {
                if (B != value)
                    SetValue(BProperty, value);
            }
        }
    }
