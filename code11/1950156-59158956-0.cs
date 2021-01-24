    public static class ReturnKeyBehavior
    {
        public static ICommand GetCommand(UIElement UIElement) =>
            (ICommand)UIElement.GetValue(CommandProperty);
        public static void SetCommand(UIElement UIElement, ICommand value) =>
            UIElement.SetValue(CommandProperty, value);
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(ReturnKeyBehavior),
            new UIPropertyMetadata(null, OnCommandChanged));
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uie = (UIElement)d;
            ICommand oldCommand = e.OldValue as ICommand;
            if (oldCommand != null)
                uie.RemoveHandler(UIElement.PreviewKeyDownEvent, (KeyEventHandler)OnMouseLeftButtonDown);
            ICommand newCommand = e.NewValue as ICommand;
            if (newCommand != null)
                uie.AddHandler(UIElement.PreviewKeyDownEvent, (KeyEventHandler)OnMouseLeftButtonDown, true);
        }
        private static void OnMouseLeftButtonDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                UIElement uie = (UIElement)sender;
                ICommand command = GetCommand(uie);
                if (command != null)
                    command.Execute(null);
            }
        }
    }
