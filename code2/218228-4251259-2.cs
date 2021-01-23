    public class DataGridTextColumnStyleHelper : FrameworkElement
    {
        public DataGridTextColumnStyleHelper(){}
        public static readonly DependencyProperty ElementStyleProperty =
            DependencyProperty.Register(
                "ElementStyle",
                typeof(Style),
                typeof(DataGridTextColumnStyleHelper));
        public Style ElementStyle
        {
            get { return (Style)GetValue(ElementStyleProperty); }
            set { SetValue(ElementStyleProperty, value); }
        }
    }
