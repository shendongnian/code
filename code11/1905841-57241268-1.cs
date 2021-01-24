    namespace MyApp.Windows
    {
        public class BaseWindow : Window
        {
            public int MyProp { get; set; }
            public BaseWindow()
            {
                Loaded += BaseWindow_Loaded;
            }
            private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
            {
            }
        }
    }
