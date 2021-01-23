    [ContentProperty("Bar")]
    public class Foo : Control
    {
        public static DependencyProperty BarProperty = DependencyProperty.Register(
            "Bar",
            typeof(int),
            typeof(Foo),
            new FrameworkPropertyMetaData(0));
        public int Bar
        {
            get { return (int)GetValue(BarProperty); }
            set { SetValue(BarProperty, value); }
        }
    }
