    public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			this.InitializeComponent();
    
    		}
    
            private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
            {
                var thumb = sender as Thumb;
                var left = (double)thumb.GetValue(Canvas.LeftProperty);
                var top = (double)thumb.GetValue(Canvas.TopProperty);
    
                if (double.IsNaN(left))
                    left = 0.0;
                if (double.IsNaN(top))
                    top = 0.0;
                left += e.HorizontalChange;
                top += e.VerticalChange;
                thumb.SetValue(Canvas.LeftProperty,left);
                thumb.SetValue(Canvas.TopProperty, top);
            }
    
            private void Thumb_DragDelta_1(object sender, DragDeltaEventArgs e)
            {            
                thumb.Width += e.HorizontalChange;
                thumb.Height += e.VerticalChange;
            }
    	}
    
        public class RectConverter : MarkupExtension,IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values == null || values.Length != 4 || values.OfType<double>().Count() != 4) return new Rect(0, 0, 0, 0);
                for (var i = 0; i < values.Length; i++)
                    if (double.IsNaN((double)values[i]))
                        values[i] = 0.0;
                return new Rect((double)values[0], (double)values[1], (double)values[2], (double)values[3]);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return new RectConverter();
            }
        }
