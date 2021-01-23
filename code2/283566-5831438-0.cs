    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                QueueManager queueManager = new QueueManager();
                Observer observer = new Observer(queueManager);
                Queue queue1 = queueManager.AddQueue();
                Queue queue2 = queueManager.AddQueue();
    
                queue1.OnNewDataAdd();
                queue2.OnNewDataAdd();
    
                Console.ReadLine();
            }
    
    
            delegate void NewDataAddedDelegate(Queue queue);
    
    
            class Queue
            {
                QueueManager queueManager;
                public string id;
                public Queue(string id, QueueManager queueManager)
                {
                    this.id = id;
                    this.queueManager = queueManager;
                }
    
                public void OnNewDataAdd()
                {
                    this.queueManager.NewDataAdded(this);
                }
            }
    
            class QueueManager
            {
                List<Queue> queues = new List<Queue>();
    
                public Queue AddQueue()
                {
                    Queue queue = new Queue((queues.Count + 1).ToString(), this);
                    this.queues.Add(queue);
                    return queue;
                }
    
                public event NewDataAddedDelegate NewDataAddedEvent;
                public void NewDataAdded(Queue queue)
                {
                    if (NewDataAddedEvent != null)
                        NewDataAddedEvent(queue);
                }
            }
    
            class Observer
            {
                public Observer(QueueManager queueManager)
                {
                    queueManager.NewDataAddedEvent += new NewDataAddedDelegate(queue_NewDataAdded);
                }
    
                void queue_NewDataAdded(Queue queue)
                {
                    Console.WriteLine("Notification to the observer from queue {0}", queue.id);
                }
            }
    
        }
    
    }
