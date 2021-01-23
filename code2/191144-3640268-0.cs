    else
    {
        //Hacky?  Perhaps... but it works.
        PresentationSource source = PresentationSource.FromVisual(this);
        KeyEventArgs ke = new KeyEventArgs(
                            Keyboard.PrimaryDevice,
                            source,
                            0,
                            System.Windows.Input.Key.Back);
        ke.RoutedEvent = UIElement.KeyDownEvent;
        System.Windows.Input.InputManager.Current.ProcessInput(ke);
    }
