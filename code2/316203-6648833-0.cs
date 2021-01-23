    public class PPMMSingleton : DependencyObject
    {
        public double? Factor
        {
            get { return (double?)GetValue(FactorProperty); }
            set { SetValue(FactorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Factor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FactorProperty =
            DependencyProperty.Register("Factor", typeof(double?), typeof(PPMMSingleton),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                    FrameworkPropertyMetadataOptions.Inherits,
                    new PropertyChangedCallback(OnFactorChanged),
                    new CoerceValueCallback(CoerceFactor)));
        private static object CoerceFactor(DependencyObject element, object value)
        {
            return value;
        }
        public static void OnFactorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            PPMMSingleton ppmm = (PPMMSingleton)sender;
            ppmmEventArgs e =
                new ppmmEventArgs(
                    (double?)args.OldValue,
                    (double?)args.NewValue);
            ppmm.OnFactorChanged(e);
        }
        private void OnFactorChanged(ppmmEventArgs e)
        {
            if (FactorChanged != null)
                FactorChanged(e);
        }
        public event ppmmEventHandler FactorChanged;
    }
