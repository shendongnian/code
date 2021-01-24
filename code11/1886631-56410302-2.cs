    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Thread(delegate()
                {
                    // Run a separate thread enforcing GC collections every second
                    while(true)
                    {
                        GC.Collect();
                        Thread.Sleep(1000);
                    }
                }).Start();
    
                while (true)
                {
                    var test = new TestNet();
                    test.Foo();
                    TestNet.Dump();
                }
            }
        }
    
        class TestNet
        {
            static ManualResetEvent _closed;
            static long _closeTime;
            static long _fooEndTime;
    
            IntPtr _nativeHandle;
    
            public TestNet()
            {
                _closed = new ManualResetEvent(false);
                _closeTime = -1;
                _fooEndTime = -1;
                _nativeHandle = CreateTestNative();
            }
    
            public static void Dump()
            {
                // Ensure the now the object will now be garbage collected
                GC.Collect();
                GC.WaitForPendingFinalizers();
    
                // Wait for current object to be garbage collected
                _closed.WaitOne();
                Trace.Assert(_closeTime != -1);
                Trace.Assert(_fooEndTime != -1);
                if (_closeTime <= _fooEndTime)
                    Console.WriteLine("WARN: Finalize() commenced before Foo() return");
                else
                    Console.WriteLine("Finalize() commenced after Foo() return");
            }
    
            ~TestNet()
            {
                _closeTime = Stopwatch.GetTimestamp();
                FreeTestNative(_nativeHandle);
                _closed.Set();
            }
    
            public void Foo()
            {
                // The native implementation just sleeps for 250ms
                TestNativeFoo(_nativeHandle);
                // Uncomment to have all Finalize() to commence after Foo()
                //GC.KeepAlive(this);
                _fooEndTime = Stopwatch.GetTimestamp();
            }
    
            [DllImport("Dll1", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr CreateTestNative();
    
            [DllImport("Dll1", CallingConvention = CallingConvention.Cdecl)]
            static extern void FreeTestNative(IntPtr obj);
    
            [DllImport("Dll1", CallingConvention = CallingConvention.Cdecl)]
            static extern void TestNativeFoo(IntPtr obj);
        }
    }
