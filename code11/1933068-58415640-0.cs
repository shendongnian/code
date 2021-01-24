    private void DummyControl_GotFocus(object sender, RoutedEventArgs e)
    {
        Save(); //save when done editing last element of detail
        Dispatcher.BeginInvoke(new Action(() => MasterDG.Focus()));
    }
