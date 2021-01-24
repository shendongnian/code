    using GalaSoft.MvvmLight.Messaging;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var message = "Test";
        Messenger.Default.Send<string,TestPage>(message);
        Tbk.Text = message;
    }
