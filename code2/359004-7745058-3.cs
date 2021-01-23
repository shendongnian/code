    public class ImageButton : Button
    {
        public static readonly DependencyProperty ActiveImageUriProperty =
            DependencyProperty.RegisterAttached("ActiveImageUri", typeof(Uri), typeof(ImageButton),
                new PropertyMetadata(null));
        public static readonly DependencyProperty InactiveImageUriProperty =
            DependencyProperty.RegisterAttached("InactiveImageUri", typeof(Uri), typeof(ImageButton),
                new PropertyMetadata(null));
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(ImageButton),
                new PropertyMetadata(false));
        public Uri ActiveImageUri
        {
            get { return (Uri)GetValue(ActiveImageUriProperty); }
            set { SetValue(ActiveImageUriProperty, value); }
        }
        public Uri InactiveImageUri
        {
            get { return (Uri)GetValue(InactiveImageUriProperty); }
            set { SetValue(InactiveImageUriProperty, value); }
        }
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
    }
