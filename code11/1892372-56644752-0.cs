    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        InputInjector inputInjector = InputInjector.TryCreate();
        for (int i = 0; i < 10; i++)
        {
            var info = new InjectedInputKeyboardInfo();
            info.VirtualKey = (ushort)(VirtualKey.Tab);
            inputInjector.InjectKeyboardInput(new[] { info });
            await Task.Delay(1000);
        }        
    }
