    using System.Diagnostics;
    
    public class DebugOutputListener : TraceListener
    {
        public event EventHandler<DebugMessageArgs> DebugMessage;
        public override void Write(string message)
        {
            EventHandler<DebugMessageArgs> h = DebugMessage;
            if (h != null)
            {
                DebugArgs args = new DebugArgs
                {
                    Message = message
                };
                h(this, args);
            }
        }
    
        public override void WriteLine(string message)
        {
            Write(message + "\r\n");
        }
    }
    
    public class DebugMessageArgs : EventArgs
    {
        public string Message
        {
            get;
            set;
        }
    }
