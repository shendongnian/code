    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                startThreadThatSignalsTerminatorAfterSomeTime();
                Console.WriteLine("Waiting for terminator to be signalled.");
                waitForTerminatorToBeSignalled();
                Console.WriteLine("Finished waiting.");
                Console.ReadLine();
            }
            private static void waitForTerminatorToBeSignalled()
            {
                _terminator.WaitOne(); // Waits forever, but you can specify a timeout if needed.
            }
            private static void startThreadThatSignalsTerminatorAfterSomeTime()
            {
                // Instead of this thread signalling the event, a thread in a completely
                // different process could do so.
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    _terminator.Set();
                });
            }
            // I'm using an EventWaitHandle rather than a ManualResetEvent because that can be named and therefore
            // used by threads in a different process. For intra-process use you can use a ManualResetEvent, which 
            // uses slightly fewer resources and so may be a better choice.
            static readonly EventWaitHandle _terminator = new EventWaitHandle(false, EventResetMode.ManualReset, "MyEventName");
        }
    }
