    public class MyEventArgs : EventArgs
    {
        private string msg;
    
        public MyEventArgs( string messageData ) 
        {
            msg = messageData;
        }
        public string Message { 
            get { return msg; } 
            set { msg = value; }
        }
    }
