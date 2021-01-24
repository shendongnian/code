    public class ViewModel : DependencyObject
    {
        private static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive",
            typeof(bool),
            typeof(ViewModel),
            new PropertyMetadata(false));
    }
