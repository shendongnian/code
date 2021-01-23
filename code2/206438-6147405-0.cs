    public ConnectResponseDTO Connect(ConnectRequestDTO request) {
        ...
        if(LoginFailed)
            OperationContext.Current.OperationCompleted += ConnectCompleted;       
    }
    private void ConnectCompleted(object sender, EventArgs e) {
        var context = (OperationContext) sender;
        context.Channel.Abort();
    }
