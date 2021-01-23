    private static void TransitionToState(object sender, DependencyPropertyChangedEventArgs args)
    {
        UserControl c = sender as UserControl;
        if (c != null && args.NewValue != null)
        {
            bool b = VisualStateManager.GoToState(c, (string)args.NewValue, true);
            var a = b;
        }
    }
