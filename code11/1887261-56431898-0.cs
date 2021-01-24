    public class CallExecutor {
        ...        
        public CallExecutor(
            SocketDestinationProvider socketDestinationProvider, Socket socket,
            MessageSender1 messageSender1, MessageSender2 messageSender2,
            ClassThatChecksSomethingOnATimer checker)
        {
            this.socketDestinationProvider = socketDestinationProvider;
            this.socket = socket;
            this.messageSender1 = messageSender1;
            this.messageSender2 = messageSender2;
            this.checker = checker;
        }
        
        public async Task Call()
        {
            EndPoint ep = await this.socketDestProvider.GetSocketDestination();
            await this.socket.ConnectAsync(ep);
            await this.sender1.SendStartMessage();
            var response = await this.sSender2.SendStartMessageAndAwaitResponse();
            if (response.Result)
            {
                this.checker.DoSomething(...)
            }
            TaskCompletionSource<int> Completion = new TaskCompletionSource<int>();
            socket.Closed += (sender, e) => { Completion.TrySetResult(0); };
            await Completion.Task;
            await this.sender2.SendStopMessage();
            await this.sender1.SendStopMessage();
            await this.socket.DisconnectAsync();        
        }
    }
