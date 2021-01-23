    public class WindowWithBindableKeys: Window {
        protected static readonly DependencyProperty BindableKeyBindingsProperty = DependencyProperty.Register(
            "BindableKeyBindings", typeof(CollectionOfYourKeyDefinitions), typeof(WindowWithBindableKeys), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnBindableKeyBindingsChanged))
        );
        public CollectionOfYourKeyDefinitions BindableKeyBindings
        {
            get
            {
                return (string)GetValue(BindableKeyBindingsProperty);
            }
            set
            {
                SetValue(BindableKeyBindingsProperty, value);
            }
        }
        private static void OnBindableKeyBindingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as WindowWithBindableKeys).InputBindings.Clear();
            // add the input bidnings according to the BindableKeyBindings
        }
    }
