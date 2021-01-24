    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Trader.Classes
    {
        public class OrderItemParams
        {
    
        }
    
        public class OrderStatus
        {
    
        }
    
        public class SemaphoreSlim
        {
            public SemaphoreSlim(int a, int b)
            {
    
            }
    
            internal Task WaitAsync()
            {
                //do stuff, not sure what?
                throw new NotImplementedException();
            }
    
            internal void Release()
            {
                throw new NotImplementedException();
            }
        }
    
        class OrderItemTask
        {
            public OrderStatus Status
            {
                get;
                private set;
            }
    
            public OrderItemParams Params
            {
                get;
                /*Sa6a: Added the set, as you were trying to assign it in public "OrderItemTask OrderItem(OrderItemParams @params)"
                        and it was telling you it is readonly */
                set;
            }
        }
    
        class SiteController
        {
            public bool Enabled { get; private set; }
    
            //set in constructor, or options somewhere
            SemaphoreSlim maxConcurrency = new SemaphoreSlim(1, 1);
    
            //Queue<OrderItemTask> orderQueue = new Queue<OrderItemTask>();
            ConcurrentQueue<OrderItemTask> orderQueue = new ConcurrentQueue<OrderItemTask>(); //Sa6a: NET 4.0 and above
            List<Task> tList = new List<Task>(); //Sa6a: It is good to have reference to the tasks you are starting, so you can manage them better 
    
            /*Sa6a: I think you do not need that look at the QueueOrder method, I am leaving only start to true for now, 
                    so we know that the whole thing is started and we can have a way to stop it if we want */
            public void Start()
            {
                Enabled = true;
    
                //lock (this)   //Sa6a: you do not need this lock, as this is not a method that can be accessed by more than one thread at a time
                //{
                //if (Enabled == false) //Sa6a: this might already be true, and if this is the case, you will end up starting another process
                //{
                //    Enabled = true;
                //    Task t = Task.Run(() => ProcessOrderWorker());
                //    tList.Add(t);
                //}
                //}
            }
    
            public void Stop()
            {
                //lock (this)  //Sa6a: you do not need this lock, as this is not a method that can be accessed by more than one thread at a time
                //{
                Enabled = false;
                tList.Clear();
                //}
            }
    
            public OrderItemTask OrderItem(OrderItemParams @params)
            {
                var task = new OrderItemTask() { Params = @params };
                QueueOrder(task);
                return task;
            }
    
    
            public void QueueOrder(OrderItemTask task)
            {
                /* Sa6a: MSN documentation does not say that Eqnqueue can throw an error, but call it a 6th sense, just have the catch
                 * https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1?redirectedfrom=MSDN&view=netframework-4.8
                 */
                try
                {
                    if (Enabled)
                    {
                        orderQueue.Enqueue(task);
    
                        //Sa6a: Start the task here if it is not runningg anymore. 
                        if (orderQueue.Count > 0)
                        {
                            Task t = Task.Run(() => ProcessOrderWorker());
                            tList.Add(t);
                        }
                    }
                    else
                    {
                        Console.WriteLine("I do not know if we need this, but the idea is if this is stopped, " +
                                "you should stop enqueuing items, and you can do this onkly if the start method is called. Another way would be to set Enabled to true automatically here?");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("This should never happen in theoery - " + ex);
                }
            }
    
            /* Sa6a: So the way I have it below is that once the items are dequeued, it should exit the task,
             *       however I am not sure what these maxConcurrency objects do, so if they make it run again, you should remove them
             */
            async Task ProcessOrderWorker()
            {
                /* Sa6a: You can put this somewhere outside or anywhere else,
                 *       The idea is that while, items are being added to the queue, they are being dequeued,
                 *       so without this you might end up in an infinite loop, if items are being added constantly and fater than they 
                 *       are being dequeued(do not argue how fast the dequeue goes, does not matter)
                 */
                int num_tasks_in_a_batch = 100;
                int counter = 0;
    
                //while true or while SiteController is enabled 
                //while (Enabled) --> Sa6a: you should not need this. If an item is added to the queue and the queue has item, the method will be called again
                //{
                try
                {
                    await maxConcurrency.WaitAsync(); //Sa6a: What is this for?
    
                    //lock (orderQueue) //Sa6a: I do not think you need a lock on the queue if it is concurrent
                    //{
                    if (orderQueue.Count > 0)
                    {
                        var batch = new List<OrderItemTask>();
                        while (orderQueue.Count > 0)
                        {
                            OrderItemTask my_task = null;
                            if (orderQueue.TryDequeue(out my_task))
                            {
                                batch.Add(my_task);
                            }
    
    
                            /* Sa6a: Explanation of this above, where the variables got declared
                             */
                            if (counter == num_tasks_in_a_batch)
                            {
                                placeOrderStrategy.PlaceOrder(batch); //Sa6a: I guess this is what you might believe would take all the time, and while this is happening items can be added to the queue
                                batch = new List<OrderItemTask>();
                            }
    
                            /*Sa6a: As the queue is concurrent and you will end up adding items, while they are being add here,
                             *      the user might try to stop the application and you might want to let them
                             */
                            if (Enabled == false)
                            {
                                break; //it should exit out of here
                            }
                        }
    
    
                        //Sa6a: You might have had 120 items in the queue. The first 100 got placed, now this will place the remainder 20
                        if (batch.Count > 0)
                        {
                            placeOrderStrategy.PlaceOrder(batch); //Sa6a: I guess this is what you might believe would take all the time, and while this is happening items can be added to the queue
                        }
    
                    }
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine("Let's printed it, so we know it has happened, if it ever does - " + ex);
                }
                finally
                {
                    maxConcurrency.Release(); //Sa6a: I do not know what this is for either
                }
                //}
            }
