    public class ViewModel : DependencyObject
    {
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive",
            typeof(bool),
            typeof(ViewModel),
            new PropertyMetadata(false));
    }
