    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var proxy = new ServiceReference1.HelloWorldServiceClient();
        proxy.SayHelloCompleted += proxy_SayHelloCompleted;
        proxy.SayHelloAsync(_nameInput.Text);
    }
    void proxy_SayHelloCompleted(object sender, ServiceReference1.SayHelloCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            this.Dispatcher.BeginInvoke(
                () => _outputLabel.Text = e.Result
            );
        }
        else
        {
            this.Dispatcher.BeginInvoke(
                () => _outputLabel.Text = e.Error.Message
            );
        }
    }
