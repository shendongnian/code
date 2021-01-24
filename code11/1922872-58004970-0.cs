    internal class WindowExtensions
    {
        public static readonly DependencyProperty WindowLoadedCommandProperty = DependencyProperty.RegisterAttached(
            "WindowLoadedCommand", typeof(ICommand), typeof(WindowExtensions), new PropertyMetadata(default(ICommand), OnWindowLoadedCommandChanged));
    
        private static void OnWindowLoadedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = d as Window;
            if (window == null)
                return;
    
            if (e.NewValue is bool newValue)
            {
                if (newValue)
                {
                    window.Loaded += WindowOnLoaded;
                }
            }
        }
    
        private static void WindowOnLoaded(object sender, RoutedEventArgs e)
        {
            Window window = sender as Window;
            if (window == null)
                return;
    
            ICommand command = GetWindowLoadedCommand(window);
            command.Execute(null);
        }
    
        public static void SetWindowLoadedCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(WindowLoadedCommandProperty, value);
        }
    
        public static ICommand GetWindowLoadedCommand(DependencyObject element)
        {
            return (ICommand) element.GetValue(WindowLoadedCommandProperty);
        }
    }
