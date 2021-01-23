     // Copied the snippet of code from the link above, just to help future readers
     MouseEventArgs e = new MouseEventArgs(Mouse.PrimaryDevice, 0);
     e.RoutedEvent = Mouse.MouseEnterEvent;
     youUIElement.RaiseEvent(e);
     // Or
     InputManager.Current.ProcessInput(e);
