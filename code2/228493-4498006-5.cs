    public class MouseDoubleClickBehavior
    {
        public static DependencyProperty MouseDoubleClickProperty =
            DependencyProperty.RegisterAttached("MouseDoubleClick",
            typeof(ICommand),
            typeof(MouseDoubleClickBehavior),
            new UIPropertyMetadata(MouseDoubleClickBehavior.MouseDoubleClickFired));
        public static void SetMouseDoubleClick(DependencyObject target, ICommand value)
        {
            target.SetValue(MouseDoubleClickBehavior.MouseDoubleClickProperty, value);
        }
        private static void MouseDoubleClickFired(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Control control = target as Control;
            if (control != null)
            {
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    control.MouseDoubleClick += MouseDoubleClick;
                }
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    control.MouseDoubleClick -= MouseDoubleClick;
                }
            }
        }
        private static void MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            ICommand command = (ICommand)control.GetValue(MouseDoubleClickBehavior.MouseDoubleClickProperty);
            object[] arguments = new object[] { };
            command.Execute(arguments);
        }
    }
