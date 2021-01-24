    public class ParameterControl : Control
    {
        public ParameterControl()
        {
            Elements = new List<Element>();
        }
        public List<Element> Elements
        {
            get { return (List<Element>)GetValue(ElementsProperty); }
            set { SetValue(ElementsProperty, value); }
        }
        public static readonly DependencyProperty ElementsProperty =
            DependencyProperty.Register("Elements", typeof(List<Element>), typeof(ParameterControl), new PropertyMetadata(null));
    }
