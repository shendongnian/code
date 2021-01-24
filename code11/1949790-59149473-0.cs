    public MainWindowViewModel(ITest test) {
        var sb = new StringBuilder();
        for (var i = 0; i < 10; i++) {
            sb.AppendLine(test.GetTime);
            Thread.Sleep(100);
        }
        Message = sb.ToString();
    }
