    public class ProgressHub : Hub
        {
            public string msg = string.Empty;
            public int count = 0;
    
            public void CallLongOperation()
            {
                Clients.Caller.sendMessage(msg, count);
            }
        }
