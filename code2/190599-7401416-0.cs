    public class WindowBase : Window
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(WindowBase), new PropertyMetadata("No Header Name Assigned"));
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            protected set { SetValue(HeaderProperty, value); }
        }
    }
    public class WindowBase<ViewModel> : WindowBase
    {
        protected ViewModel Model { get; set; }
    }
