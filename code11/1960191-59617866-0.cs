    public class OpenContextMenuOnLeftClickBehavior : DependencyObject
    {
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        /// <summary>
        /// The DependencyProperty that backs the IsEnabled property.
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled", typeof(bool), typeof(OpenContextMenuOnLeftClickBehavior), new FrameworkPropertyMetadata(false, IsEnabledProperty_Changed));
        /// <summary>
        /// The property changed callback for the IsEnabled dependency property.
        /// </summary>
        /// <param name="dpobj">
        /// The dependency object whose property changed.
        /// </param>
        /// <param name="args">
        /// The event arguments.
        /// </param>
        private static void IsEnabledProperty_Changed(DependencyObject dpobj, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement f = dpobj as FrameworkElement; 
            if (f != null)
            {
                bool newValue = (bool)args.NewValue;
                if (newValue)
                    f.PreviewMouseLeftButtonUp += Target_PreviewMouseLeftButtonUpEvent;
                else
                    f.PreviewMouseLeftButtonUp -= Target_PreviewMouseLeftButtonUpEvent;
            }
        }
        protected static void Target_PreviewMouseLeftButtonUpEvent(object sender, RoutedEventArgs e)
        {
            FrameworkElement f = sender as FrameworkElement;
            if (f?.ContextMenu != null)
            {
                f.ContextMenu.PlacementTarget = f;
                f.ContextMenu.IsOpen = true;
            }
            e.Handled = true;
        }
    }
