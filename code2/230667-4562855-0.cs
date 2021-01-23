        private void SameViewButDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ChangeFocusDelegate focusDelegate = FocusFileSearchButton;
            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, focusDelegate);
        }
