      public static void RaiseMenuItemClickOnKeyGesture(this ItemsControl control, KeyEventArgs args)
      {
          RaiseMenuItemClickOnKeyGesture(control, args, true);
      }
    
      public static void RaiseMenuItemClickOnKeyGesture(this ItemsControl control, KeyEventArgs args, bool throwOnError)
      {
          if (args == null)
              throw new ArgumentNullException("e");
    
          if (control == null)
              return;
    
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
                      }
                  }
    
                  if (gesture != null && gesture.Matches(null, args))
                  {
                      item.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                      args.Handled = true;
                      return;
                  }
              }
    
              RaiseMenuItemClickOnKeyGesture(item, args, throwOnError);
              if (args.Handled)
                  return;
          }
      }
