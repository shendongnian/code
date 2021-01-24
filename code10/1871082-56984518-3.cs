    public class DeferredMessageSender {
        Queues queues;
        IHubContext<MyHub, IMyEvents> hub;
        public DeferredMessageSender(Queues queues, IHubContext<MyHub, IMyEvents> hub) {
            this.queues = queues;
            this.hub = hub;
        }
        public void GlobalSend() {
            while(queues.MessagesQueue.TryDequeue(out var evt)) {
                evt.Invoke(hub);
            }
        }
    }
