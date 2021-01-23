    var flowDocument = 
        (FlowDocument)Application.LoadComponent(
            new Uri(@"SomeFlowDocument.xaml", UriKind.Relative));
    flowDocument.DataContext = this;
 
    Dispatcher.CurrentDispatcher.Invoke(
        DispatcherPriority.SystemIdle,
        new DispatcherOperationCallback(arg => null ), null);
