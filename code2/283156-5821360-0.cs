    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading;
    namespace ProducerConsumerDemo
    {
      class Program
      {
        static BlockingCollection<int> _queue = new BlockingCollection<int>();
        static ManualResetEvent _pauseConsumers = new ManualResetEvent(true);
        static bool _paused = false;
        static int _itemsEnqueued = 0;
        static int _itemsDequeued = 0;
        static void Main(string[] args)
        {
          Thread producerThread = new Thread(Producer);
          Thread consumerThread1 = new Thread(Consumer);
          Thread consumerThread2 = new Thread(Consumer);
          producerThread.Start();
          consumerThread1.Start();
          consumerThread2.Start();
          while (true)
          {
            WriteAt(0,0,"State: " + (string)(_paused ? "Paused" : "Running"));
            WriteAt(0,1,"Items In Queue: " + _queue.Count);
            WriteAt(0, 2, "Total enqueued: " + _itemsEnqueued);
            WriteAt(0, 3, "Total dequeued: " + _itemsDequeued);
        
            Thread.Sleep(100);
            if (Console.KeyAvailable)
            {
              if (Console.ReadKey().Key == ConsoleKey.Spacebar)
              {
                if (_paused)
                {
                  _paused = false;
                  _pauseConsumers.Set();
                }
                else
                {
                  _paused = true;
                  _pauseConsumers.Reset();
                }
              }
            }
          }
        }
        static void WriteAt(int x, int y, string format, params object[] args)
        {
          Console.SetCursorPosition(x, y);
          Console.Write("                                         ");
          Console.SetCursorPosition(x, y);
          Console.Write(format, args);
        }
        static void Consumer()
        {
          while (true)
          {
            if (_paused)
            {
              // If we are paused, wait for the signal to indicate that
              // we can continue
              _pauseConsumers.WaitOne();
            }
            int value;
            if (_queue.TryTake(out value))
            {
              Interlocked.Increment(ref _itemsDequeued);
              // Do something with the data
            }
            Thread.Sleep(500);
          }
        }
        static void Producer()
        {
          Random rnd = new Random();
          while (true)
          {
            if (_queue.TryAdd(rnd.Next(100)))
            {
              Interlocked.Increment(ref _itemsEnqueued);
            }
            Thread.Sleep(500);
          }
        }
      }
    }
