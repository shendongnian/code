        public enum MidpointSide { None, Left, Top, Right, Bottom }
    
        public class MidpointConverter : IValueConverter
        {
            private bool returnY;
            public MidpointConverter(bool returnY)
            {
                this.returnY = returnY;
            }
            public object Convert(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                var scatter = value as ScatterViewItem;
                var side = (MidpointSide)parameter;
                var center = scatter.ActualCenter;
                var halfW = scatter.ActualWidth / 2.0;
                var halfH = scatter.ActualHeight / 2.0;
                Point point = null;
                switch (side)
                {
                case MidpointSide.Left:
                    point = new Point(center.X - halfW, center.Y);
                    break;
                case MidpointSide.Top:
                    point = new Point(center.X, center.Y - halfH);
                    break;
                case MidpointSide.Right:
                    point = new Point(center.X + halfW, center.Y);
                    break;
                case MidpointSide.Bottom:
                    point = new Point(center.X, center.Y + halfH);
                    break;
                default:
                    return null;
                }
                return this.returnY ? point.Y : point.X;
            }
            public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    The converter you would use would be:
        var x = new MidpointConverter(false), y = MidpointConverter(true);
        BindingOperations.SetBinding(line, Line.X1Property,
            new Binding { Source = origin, Converter = x, ConverterParameter = MidpointSide.Bottom });
        BindingOperations.SetBinding(line, Line.Y1Property,
            new Binding { Source = origin, Converter = y, ConverterParameter = MidpointSide.Bottom });
        // Definitely more heavyweight than just changing the `ZIndex`
