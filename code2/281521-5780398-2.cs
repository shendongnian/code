    DispatcherFrame frame = new DispatcherFrame();
    Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate(object parameter) {
                    frame.Continue = false;
                    return null;
                }), null);
                Dispatcher.PushFrame(frame);
