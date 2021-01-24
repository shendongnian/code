        public void someFunction()
        {
            this.Device.ResponseHandler.Process(
                this.Device.TcpClient.responseMessage,
                this.Device.TcpClient.responseType
            );
        }
