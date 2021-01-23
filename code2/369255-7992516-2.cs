      private static void CustomGridBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
      {
         WindowName win = (WindowName)sender;
         if (win.PropertyChanged != null)
         {
            // at this place the gui will be reloaded
            win.PropertyChanged(win, new PropertyChangedEventArgs(null));
         }
      }
