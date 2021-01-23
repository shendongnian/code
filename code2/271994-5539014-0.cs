    class Program
        {
            static void Main(string[] args)
            {
                Thread t1 = new Thread(Task1);
                ManualResetEvent e1=new ManualResetEvent(false);
    
                Thread t2 = new Thread(Task2);
                ManualResetEvent e2=new ManualResetEvent(false);
    
                Thread t3 = new Thread(Task3);
                ManualResetEvent e3=new ManualResetEvent(false);
    
                t1.Start(()=>Take1(e1));
                t2.Start(()=>Take2(e1,e2));
                t3.Start(()=>Take3(e3);
    
                Console.Read();
    
                t1.Join();
                t2.Join();
                t3.Join();
            }
    
            public static void Task1(EventWaitHandle handle)
            {
                Console.WriteLine("I am assigned task 1:");
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Task1" );
                }
                handle.Set();
    
            }
            public static void Task2(EventWaitHandle waitFor, EventWaitHandle handle)
            {
                waitFor.WaitOne();
    
                Console.WriteLine("I am assigned task 2:");
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Task2");
                }
    
                handle.Set();
            }
            public static void Task3(EventWaitHandle waitFor)
            {
                waitFor.WaitOne();
    
                Console.WriteLine("I am assigned task 3:");
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Task3");
                }
            }
        }
