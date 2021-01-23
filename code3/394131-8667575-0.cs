    label.Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(
            delegate()
            {
              label.Content = printerStatus();
            }
        ));
