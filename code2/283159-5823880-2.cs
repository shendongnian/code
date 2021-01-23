    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using System.Collections;
    using System.Collections.Concurrent;
    
    namespace WindowsFormsApplication2
    {
        static class Program
        {
            private static void Producer()
            {
                int i = 0;
                while (i < 500)
                {
                    Thread.Sleep(50); // can remove the sleep just for debugging
                    bc.ProducerAdd("Notification " + i);
                    i++;
                }
            }
    
            private static void Consumer()
            {
                while (true)
                {
                    foreach (var it in bc)
                    {
                        Console.WriteLine(String.Format("{0} : CONSUMES {1}", Thread.CurrentThread.Name, it));
    
                        // this is just a check test
                        lock (consumed)
                        {
                            consumed.Add(it, Convert.ToInt32(it.Split(' ')[1])); // this will fail if we consume the same twice
                        }
                    }
                }
            }
    
            private static void TogglePause()
            {
                while (true)
                {
                    Thread.Sleep(3000); //every 3 seconds
                    bc.Paused = !bc.Paused;
                    Console.WriteLine("PAUSE is now: " + bc.Paused);
                }
            }
    
            private static QueuedBlockingCollection<string> bc = new QueuedBlockingCollection<string>();
            private static Dictionary<string, int> consumed = new Dictionary<string, int>();
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Thread producer = new Thread(Producer);
                producer.Start();
    
                Thread consumer1 = new Thread(Consumer);
                consumer1.Name = "Consumer 1";
                consumer1.Start();
    
                Thread consumer2 = new Thread(Consumer);
                consumer2.Name = "Consumer 2";
                consumer2.Start();
    
                Thread pauser = new Thread(TogglePause);
                pauser.Start();
    
                while (true)
                {
                    // wait and observe console writelines
                    Application.DoEvents();
                }
            }
        }
    
        class QueuedBlockingCollection<T> : IEnumerable<T>, ICollection, IEnumerable, IDisposable
        {
            private Queue<T> queue = new Queue<T>();
            private BlockingCollection<T> collection = new BlockingCollection<T>();
            private Thread syncThread;
    
            public bool Paused { get; set; }
            public bool Exiting { get; set; }
    
            private void SyncLoop()
            {
                // this while will wait for the class to be destroyed
                while (!Exiting)
                {
                    try
                    {
                        // this while will finish when queue is synched to collection, or paused or exiting
                        while (queue.Count > 0 && !Exiting && !Paused)
                        {
                            lock (collection)
                            {
                                T item = queue.Dequeue();
                                collection.Add(item);
                                Console.WriteLine(String.Format("SYNCHED {0} TO COLLECTION", item));
                            }
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        // collection has been disposed, exit this thread
                        break;
                    }
                }
            }
    
            public void ProducerAdd(T item)
            {
                // producer always adds to the queue if the collection is paused so it wont block the collection
                // the sync thread will block the collection only when adding from the queue
                // consumers automatically block this collection when enumerating because it is a wrapper to the internal blocked coll...
                if (!Paused)
                {
                    lock (collection)
                    {
                        collection.Add(item);
                        Console.WriteLine(String.Format("Producer ADDED '" + item + "', status collection {0} queue {1}", this.Count, queue.Count));
                    }
                }
                else
                {
                    queue.Enqueue(item);
                    Console.WriteLine(String.Format("Producer ENQUEUED '" + item + "', Status -> Collection: {0}, Queue: {1}", this.Count, queue.Count));
                }
            }
    
            public QueuedBlockingCollection()
            {
                //collection.CompleteAdding();
                syncThread = new Thread(SyncLoop);
                syncThread.Start();
            }
    
            ~QueuedBlockingCollection()
            {
                Exiting = true;
                syncThread.Join(200);
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return collection.GetConsumingEnumerable().GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return collection.GetConsumingEnumerable().GetEnumerator();
            }
    
            public void CopyTo(Array array, int index)
            {
                var items = collection.GetConsumingEnumerable();
                int offset = 0;
    
                if (array == null) throw new NullReferenceException("Array must be initialized");
                if (array.Rank > 1) throw new InvalidOperationException("Array must have 1 dimension");
                if (array.GetLength(0) - index < items.Count()) throw new IndexOutOfRangeException("Array is too small");
    
                foreach (var item in items)
                {
                    array.SetValue(item, index + offset);
                    offset++;
                }
    
            }
    
            public int Count
            {
                get
                {
                    return collection.Count;
                }
            }
    
            public bool IsSynchronized
            {
                get { return queue.Count == 0; }
            }
    
            public object SyncRoot
            {
                get { return collection; }
            }
    
            public void Dispose()
            {
                collection.Dispose();
            }
    
        }
    }
