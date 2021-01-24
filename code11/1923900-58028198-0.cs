    using ResponseHandler = this.Device.ResponseHandler;
    using TcpClient = this.Device.TcpClient;
    
    public void someFunction()
    {
        ResponseHandler.Process(TcpClient.responseMessage, TcpClient.responseType);
    }
