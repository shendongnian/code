    public ConnectResponseDTO Connect(ConnectRequestDTO request) {
        ...
        if(LoginFailed)
            OperationContext.Current.OperationCompleted += FaultSession;       
    }
    private void FaultSession(object sender, EventArgs e) {
        var context = (OperationContext) sender;
        context.Channel.Abort();
    }
