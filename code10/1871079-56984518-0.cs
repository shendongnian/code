    public interface IMyEvents {
        void ReceiveMessage(string myMessage);
    }
    public class MyHub : Hub<IMyEvents> {
        Queues queues;
        string callerId;
        public MyHub(Queues queues) {
            this.queues = queues;
            this.callerId = Context.ConnectionId;
        }
        public void SendMessage(string message) {
            queues.MessagesQueue.Enqueue(hub => hub.Clients.Client(callerId).ReceiveMessage(message));
        }
        // This will crash
        public void SendMessage_BAD(string message) {
            queues.MessagesQueue.Enqueue(_ => this.Clients.Client(callerId).ReceiveMessage(message));
        }
        public void BroadcastMessage(string message) {
            queues.MessagesQueue.Enqueue(hub => hub.Clients.All.ReceiveMessage(message));
        }
    }
