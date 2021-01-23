    using System;
    using System.Threading;
    
    class Program
    {
        static AutoResetEvent _ExceptionEvent = new AutoResetEvent(false);
        static WaitHandle _SomeEvent = new AutoResetEvent(false);
        static WaitHandle[] _Waiters = new WaitHandle[] { _ExceptionEvent, _SomeEvent };
        static Exception _LastThrownException = null;
    
        static int _CatchedExCount = 0;
        static void ThreadA()
        {
            while (true)
            {
                int eventIdx = WaitHandle.WaitAny(_Waiters);
                if (eventIdx == 0) // Exception event
                {
                    Exception lastEx = Interlocked.Exchange(ref _LastThrownException, null);
                    if (lastEx != null)
                    {
                        Console.WriteLine("Thread A got exception {0}", lastEx.Message);
                        _CatchedExCount++;
                        //throw lastEx;
                    }
                }
            }
    
        }
    
        static void ThreadB()
        {
            while (true)
            { 
                try
                {
                    ThreadBWorker();
                }
                catch (Exception ex) 
                {
                    // Do not overwrite a pending exception until it was processed
                    Exception old = null;
                    do
                    {
                        old = Interlocked.CompareExchange(ref _LastThrownException, ex, null);
                        if( old != null) // wait a bit to allow processing of existing exception
                        {
                            Thread.Sleep(1);
                        }
                    }
                    while (old != null);
                    _ExceptionEvent.Set();
                }
            }
        }
    
        static int _exCount = 0;
        static void ThreadBWorker()
        {
            throw new Exception("Thread B Exception " + _exCount++);
        }
    
        static void Main(string[] args)
        {
            Thread t2 = new Thread(ThreadB);
            t2.Start();  // start producing exception
    
            Thread t1 = new Thread(ThreadA);
            t1.Start(); // wait for exceptions
        }
    }
