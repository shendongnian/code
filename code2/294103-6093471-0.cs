    /// <summary>
    /// The WaitFreeQueue class implements the Queue abstract data type through a linked list. The WaitFreeQueue
    /// allows thread-safe addition and removal of elements using atomic operations. Multiple threads can add
    /// elements simultaneously, and another thread can remove elements from the queue at the same time. Only one
    /// thread can remove elements from the queue at any given time.
    /// </summary>
    /// <typeparam name="T">The type parameter</typeparam>
    public class WaitFreeQueue<T>
    {
        // Private fields
        // ==============
        #region Private fields
        private Node<T> _tail;  // The tail of the queue.
        private Node<T> _head;  // The head of the queue.
        #endregion
        // Public methods
        // ==============
        #region Public methods
        /// <summary>
        /// Removes the first item from the queue. This method returns a value to indicate if an item was
        /// available, and passes the item back through an argument.
        /// This method is not thread-safe in itself (only one thread can safely access this method at any
        /// given time) but it is safe to call this method while other threads are enqueueing items.
        /// 
        /// If no item was available at the time of calling this method, the returned value is initialised
        /// to the default value that matches this instance's type parameter. For reference types, this is
        /// a Null reference.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A boolean value indicating if an element was available (true) or not.</returns>
        public bool Dequeue(ref T value)
        {
            bool succeeded = false;
            value = default(T);
            // If there is an element on the queue then we get it.
            if (null != _head)
            {
                // Set the head to the next element in the list, and retrieve the old head.
                Node<T> head = System.Threading.Interlocked.Exchange<Node<T>>(ref _head, _head.Next);
                
                // Sever the element we just pulled off the queue.
                head.Next = null;
                
                // We have succeeded.
                value = head.Value;
                succeeded = true;
            }
            return succeeded;
        }
        /// <summary>
        /// Adds another item to the end of the queue. This operation is thread-safe, and multiple threads
        /// can enqueue items while a single other thread dequeues items.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void Enqueue(T value)
        {
            // We create a new node for the specified value, and point it to itself.
            Node<T> newNode = new Node<T>(value);
            // In one atomic operation, set the tail of the list to the new node, and remember the old tail.
            Node<T> previousTail = System.Threading.Interlocked.Exchange<Node<T>>(ref _tail, newNode);
            // Link the previous tail to the new tail.
            if (null != previousTail)
                previousTail.Next = newNode;
            // If this is the first node in the list, we save it as the head of the queue.
            System.Threading.Interlocked.CompareExchange<Node<T>>(ref _head, newNode, null);
        } // Enqueue()
        #endregion
        // Public constructor
        // ==================
        #region Public constructor
        /// <summary>
        /// Constructs a new WaitFreeQueue instance.
        /// </summary>
        public WaitFreeQueue() { }
        /// <summary>
        /// Constructs a new WaitFreeQueue instance based on the specified list of items.
        /// The items will be enqueued. The list can be a Null reference.
        /// </summary>
        /// <param name="items">The items</param>
        public WaitFreeQueue(IEnumerable<T> items)
        {
            if(null!=items)
                foreach(T item in items)
                    this.Enqueue(item);
        }
        #endregion
        // Private types
        // =============
        #region Private types
        /// <summary>
        /// The Node class represents a single node in the linked list of a WaitFreeQueue.
        /// It contains the queued-up value and a reference to the next node in the list.
        /// </summary>
        /// <typeparam name="U">The type parameter.</typeparam>
        private class Node<U>
        {
            // Public fields
            // =============
            #region Public fields
            public Node<U> Next;
            public U Value;
            #endregion
            // Public constructors
            // ===================
            #region Public constructors
            /// <summary>
            /// Constructs a new node with the specified value.
            /// </summary>
            /// <param name="value">The value</param>
            public Node(U value)
            {
                this.Value = value;
            }
            #endregion
        } // Node generic class
        #endregion
    } // WaitFreeQueue class
