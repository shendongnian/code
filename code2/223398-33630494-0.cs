    public void Execute(object parameter)
    {
        _mainViewModel.SaveSomething();
        var editWindow = parameter as MyEditWindow;
        editWindow?.Close();
    }
