    public class ViewModel : DependencyObject
    {
        public static readonly DependencyProperty IsExistProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(ViewModel), new PropertyMetadata(false));
    }
