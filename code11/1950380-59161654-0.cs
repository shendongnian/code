    [HubName("SignalRHub")]
    public class SignalRHub1 : Hub {
     
        public void GetCallControlData() {
            Clients.Caller.SetServer("Server");
        }
    }
