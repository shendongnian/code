        public void MyServiceOperation()
        {
            string userName = WebOperationContext.Current.IncomingRequest
                .Headers["X-UserName"];
            // ...
        }
