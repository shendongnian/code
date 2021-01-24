    public class ColorSlider : Slider
    {
        public static readonly DependencyProperty Width1Property = DependencyProperty.Register("Width1", typeof(double), typeof(ColorSlider), new UIPropertyMetadata(0.0));
        [TypeConverter(typeof(LengthConverter))]
        public double Width1
        {
            get { return (double)GetValue(Width1Property); }
            set { SetValue(Width1Property, value); }
        }
