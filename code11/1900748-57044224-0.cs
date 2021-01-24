    public static void DoEvents()
    {
      Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;
      dispatcher.Invoke(DispatcherPriority.Background, () => {  });
    }
