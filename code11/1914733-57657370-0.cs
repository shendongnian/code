    [ContentProperty(nameof(Children))]
    public class CustomFilter : Control
    {
        static CustomFilter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomFilter), new FrameworkPropertyMetadata(typeof(CustomFilter)));
        }
        public CustomFilter()
        {
            SetValue(ChildrenPropertyKey, new List<UIElement>());
        }
        private static readonly DependencyPropertyKey ChildrenPropertyKey =
                DependencyProperty.RegisterReadOnly(
                  nameof(Children),
                  typeof(List<UIElement>),
                  typeof(CustomFilter),
                  new FrameworkPropertyMetadata(new List<UIElement>())
                );
        public static readonly DependencyProperty ChildrenProperty =
            ChildrenPropertyKey.DependencyProperty;
        public List<UIElement> Children
        {
            get { return (List<UIElement>)GetValue(ChildrenProperty); }
        }
    }
