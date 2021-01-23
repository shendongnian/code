    using namespace Utility{
        public static class DebugVisibility
        {
            public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached(
        "Debug", typeof(bool?), typeof(DebugVisibility), new PropertyMetadata(default(bool?), IsVisibleChangedCallback));
    
            private static void IsVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var fe = d as FrameworkElement;
                if (fe == null)
                    return;
    #if DEBUG
                fe.Visibility = Visibility.Visible;
    #else
                fe.Visibility = Visibility.Collapsed;
    #endif
            }
    
            public static void SetIsVisible(DependencyObject element, bool? value)
            {
                element.SetValue(IsVisibleProperty, value);
            }
    
            public static bool? GetIsVisible(DependencyObject element)
            {
                return (bool?)element.GetValue(IsVisibleProperty);
            }
        }
    }
