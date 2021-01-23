    class AWrapper : IConnectable
    {
        private A obj;
    
        public AWrapper(A obj)
        {
            this.obj = obj;
        }
    
        public void Connect()
        {
            this.obj.Connect();
        }
        
        public void Disconnect()
        {
            this.obj.Disconnect();
        }
    
        // other methods as necessary
    }
