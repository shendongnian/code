    public class MyControl : Control 
    {
        [TypeConverter(typeof(MyStringToPointCollectionConverter))]
        public ObservableCollection<Point> Points {
            get { return (ObservableCollection<Point>)GetValue(Points yProperty); }
            set { SetValue(Points Property, value); }
        }
        ...
    }
