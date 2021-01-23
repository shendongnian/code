    public sealed class CustomQueue<T> where T : class
    {
        private readonly object pushLocker = new object();
        private readonly object popLocker = new object();
        private readonly Semaphore queueSemaphore;
        private readonly int maxItems;
        private volatile int pushIncrement;
        private volatile int popIncrement;
        private Node firstNode = new Node();
        private Node lastNode;
        public CustomQueue(int maxItems)
        {
            this.maxItems = maxItems;
            this.lastNode = this.firstNode;
            this.queueSemaphore = new Semaphore(0, this.maxItems);
        }
        public int Size
        {
            get
            {
                return this.pushIncrement - this.popIncrement;
            }
        }
        public bool Push(T value)
        {
            lock (this.pushLocker)
            {
                if (this.Size >= this.maxItems)
                {
                    lock (this.popLocker)
                    {
                        this.pushIncrement = this.pushIncrement - this.popIncrement;
                        this.popIncrement = 0;
                        return false;
                    }
                }
                Node newNode = new Node(value, this.lastNode.NextNode);
                this.lastNode = new Node(this.lastNode.Value, newNode);
                this.firstNode = new Node(null, newNode);
                this.pushIncrement++;
                this.queueSemaphore.Release();
                return true;
            }
        }
        public T Pop()
        {
            this.queueSemaphore.WaitOne();
            lock (this.popLocker)
            {
                Node tempNext = this.firstNode.NextNode;
                T value = tempNext.Value;
                this.firstNode = tempNext;
                this.popIncrement++;
                return value;
            }
        }
        private sealed class Node
        {
            private readonly T value;
            private readonly Node nextNode;
            public Node()
            {
            }
            public Node(T value, Node nextNode)
            {
                this.value = value;
                this.nextNode = nextNode;
            }
            public T Value
            {
                get
                {
                    return this.value;
                }
            }
            public Node NextNode
            {
                get
                {
                    return this.nextNode;
                }
            }
        }
    }
