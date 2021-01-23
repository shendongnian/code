    public class AttachedEvents
    {
        private static readonly DependencyProperty IsTriggerEnabledProperty =
            DependencyProperty.RegisterAttached("IsTriggerEnabled", typeof(bool), typeof(FrameworkElement), new FrameworkPropertyMetadata(false));
    
        public static readonly RoutedEvent ClickEvent;
    
        static AttachedEvents()
        {
            try
            {
                ClickEvent = EventManager.RegisterRoutedEvent("Click",
                                                            RoutingStrategy.Bubble,
                                                            typeof(RoutedEventHandler),
                                                            typeof(FrameworkElement));
            }
            catch (Exception ex)
            { }
        }
    
    
        private static void SetIsTriggerEnabled(FrameworkElement element, bool value)
        {
            if (element != null)
            {
                element.SetValue(IsTriggerEnabledProperty, value);
            }
        }
    
        private static bool GetIsTriggerEnabled(FrameworkElement element)
        {
            return (element != null) ? (bool)element.GetValue(IsTriggerEnabledProperty) : false;
        }
    
        public static void AddClickHandler(DependencyObject o, RoutedEventHandler handler)
        {
            FrameworkElement element = (FrameworkElement)o;
            element.AddHandler(ClickEvent, handler);
            element.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(SimulatedClick_MouseLeftButtonUp);
            element.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(SimulatedClick_MouseLeftButtonDown);
        }
            
        public static void RemoveClickHandler(DependencyObject o, RoutedEventHandler handler)
        {
            FrameworkElement element = (FrameworkElement)o;
            element.RemoveHandler(ClickEvent, handler);
            element.MouseLeftButtonUp -= new System.Windows.Input.MouseButtonEventHandler(SimulatedClick_MouseLeftButtonUp);
            element.PreviewMouseLeftButtonDown -= new System.Windows.Input.MouseButtonEventHandler(SimulatedClick_MouseLeftButtonDown);
        }
    
        static void SimulatedClick_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            UpdateIsTriggerSet(element);
            Mouse.Capture(element);
        }
    
        static void SimulatedClick_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
    
            bool isTriggerSet = (bool)element.GetValue(IsTriggerEnabledProperty);
    
            // update the trigger set flag
            UpdateIsTriggerSet(element);
    
            //release the mouse capture
            Mouse.Capture(null);
    
            // if trigger is set and we are still over the element then we fire the click event
            if (isTriggerSet && IsMouseOver(element))
            {
                element.RaiseEvent(new RoutedEventArgs(ClickEvent, sender));
            }
    
        }
    
        private static bool IsMouseOver(FrameworkElement element)
        {
            Point position = Mouse.PrimaryDevice.GetPosition(element);
            if (((position.X >= 0.0) && (position.X <= element.ActualWidth)) && ((position.Y >= 0.0) && (position.Y <= element.ActualHeight)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        private static void UpdateIsTriggerSet(FrameworkElement element)
        {
            Point position = Mouse.PrimaryDevice.GetPosition(element);
            if (((position.X >= 0.0) && (position.X <= element.ActualWidth)) && ((position.Y >= 0.0) && (position.Y <= element.ActualHeight)))
            {
                if (!(bool)element.GetValue(IsTriggerEnabledProperty))
                {
                    element.SetValue(IsTriggerEnabledProperty, true);
                }
            }
            else if ((bool)element.GetValue(IsTriggerEnabledProperty))
            {
                element.SetValue(IsTriggerEnabledProperty, false);
            }
        }
    }
