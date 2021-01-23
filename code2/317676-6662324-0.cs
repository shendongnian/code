    private void RaiseDelayedTextChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(DelayTextBox.DelayedTextChangedEvent);
            
            this.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    (UpdateTheUI)delegate(RoutedEventArgs eArgs)
                    {
                       RaiseEvent(eArgs);
                    }, newEventArgs );
        }
