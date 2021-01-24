    public interface IMyEvents {
        void ReceiveMessage(string myMessage);
    }
    public class MyHub : Hub<IMyEvents> {
        Queues queues;
        public MyHub(Queues queues) {
            this.queues = queues;
        }
        public void SendMessage(string message) {
            var callerId = Context.ConnectionId;
            queues.MessagesQueue.Enqueue(hub => hub.Clients.Client(callerId).ReceiveMessage(message));
        }
        // This will crash
        public void SendMessage_BAD(string message) {
            this.callerId = Context.ConnectionId;
            queues.MessagesQueue.Enqueue(_ => this.Clients.Client(callerId).ReceiveMessage(message));
        }
        public void BroadcastMessage(string message) {
            queues.MessagesQueue.Enqueue(hub => hub.Clients.All.ReceiveMessage(message));
        }
    }
