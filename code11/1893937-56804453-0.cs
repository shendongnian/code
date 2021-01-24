c#
...
        public static readonly DependencyProperty IsPanelOpenCommandProperty =
            DependencyProperty.RegisterAttached("IsPanelOpenCommand", typeof(ICommand),
            typeof(ItemClickCommand), null);
        public static void SetIsPaneOpenCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(IsPanelOpenCommandProperty, value);
        }
        public static ICommand GetIsPaneOpenCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(IsPanelOpenCommandProperty);
        }
        
        // in item click insert the following
        var paneCommand = GetIsPaneOpenCommand(control);
        if (paneCommand != null)
           paneCommand.Execute();
....
