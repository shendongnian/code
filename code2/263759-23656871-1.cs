    public static bool RaiseMenuItemClickOnKeyGesture(this ItemsControl control, KeyEventArgs args)
    {
        return RaiseMenuItemClickOnKeyGesture(control, args, true);
    }
    
    public static bool RaiseMenuItemClickOnKeyGesture(this ItemsControl control, KeyEventArgs args, bool throwOnError)
    {
        if (control == null)
            throw new ArgumentNullException("control");
    
        if (args == null)
            throw new ArgumentNullException("args");
    
        KeyGestureConverter kgc = new KeyGestureConverter();
        foreach(var item in control.Items.OfType<MenuItem>())
        {
            if (!string.IsNullOrWhiteSpace(item.InputGestureText))
            {
                KeyGesture gesture = null;
                if (throwOnError)
                {
                    gesture = kgc.ConvertFrom(item.InputGestureText) as KeyGesture;
                }
                else
                {
                    try
                    {
                        gesture = kgc.ConvertFrom(item.InputGestureText) as KeyGesture;
                    }
                    catch
                    {
                        // do nothing and go on
                    }
                }
    
                if (gesture != null && gesture.Matches(null, args))
                {
                    item.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                    args.Handled = true;
                    return true;
                }
            }
    
            if (RaiseMenuItemClickOnKeyGesture(item, args, throwOnError))
                return true;
        }
        return false;
    }
