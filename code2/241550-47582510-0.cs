    namespace Blokick.Provider
    {
        public class SignalRConnectProvider
        {
            public SignalRConnectProvider()
            {
            }
    
            public bool IsStopRequested { get; set; } = false; //1-)This is important and default `false`.
    
            public async Task<string> ConnectTab()
            {
                string messageText = "";
                for (int count = 1; count < 20; count++)
                {
                    if (count == 1)
                    {
                    //Do stuff.
                    }
    
                    try
                    {
                    //Do stuff.
                    }
                    catch (Exception ex)
                    {
                    //Do stuff.
                    }
                    if (IsStopRequested) //3-)This is important. The control of the task stopping request. Must be true and in inside.
                    {
                        return messageText = "Task stopped."; //4-) And so return and exit the code and task.
                    }
                    if (Connected)
                    {
                    //Do stuff.
                    }
                    if (count == 19)
                    {
                    //Do stuff.
                    }
                }
                return messageText;
            }
        }
    }
