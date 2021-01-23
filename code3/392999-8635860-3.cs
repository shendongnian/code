    public class BehaviourQueue : Queue<BehaviourQueueItem<T>>,  IBehaviourQueue<T> where T : IBehaviour
    {
        private IBehaviourFactory factory;
    
        public BehaviourQueue(IBehaviourFactory factory)
        {
            this.factory = factory;
        }
    
        public BehaviourQueueItem<T> AddBehaviour()
        {
            T behaviour = factory.GetNew<T>();
            var queueItem = new BehaviourQueueItem<T>(behaviour);
            Enqueue(queueItem); 
            return queueItem;
        }
    
        public void Run()
        {
            //Run each queue item
        }
    
    }
