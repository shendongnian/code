    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static CountdownEvent countdown;
            static void Main(string[] args)
            {
                countdown = new CountdownEvent(1);
                for (int i = 1; i < 5; i++)
                {
                    //do stuff to start background thread
                    countdown.AddCount(); //add a count for each
                }
                countdown.Signal(); //subtract your initial count
                countdown.Wait(); //wait until countdown reaches zero
                //done!
            }
            static void backgroundwork()
            {
                //work
                countdown.Signal(); //signal this thread's completion (subtract one from count)
            }
        }
    }
