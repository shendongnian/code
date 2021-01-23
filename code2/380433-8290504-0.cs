    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Test
    {
        public class Program
        {
            private static ConcurrentQueue<ConsoleKeyInfo> _keypresses = new ConcurrentQueue<ConsoleKeyInfo>();
            private static ManualResetEventSlim _stopEvent = new ManualResetEventSlim();
            public static void Main()
            {
                Console.TreatControlCAsInput = true;
                var keyReaderTask = Task.Factory.StartNew(ReadKeys);
                var keyProcessingTask = Task.Factory.StartNew(ProcessKeys);
                _stopEvent.Wait();
                keyReaderTask.Wait();
                keyProcessingTask.Wait();
            }
            public static void ReadKeys()
            {
                while (true)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Modifiers == ConsoleModifiers.Control && keyInfo.Key == ConsoleKey.C)
                    {
                        break;
                    }
                    _keypresses.Enqueue(keyInfo);
                }
                _stopEvent.Set();
            }
            public static void ProcessKeys()
            {
                while (!_stopEvent.IsSet)
                {
                    if (!_keypresses.IsEmpty)
                    {
                        Console.Write("Keys: ");
                        ConsoleKeyInfo keyInfo;
                        while (_keypresses.TryDequeue(out keyInfo))
                        {
                            Console.Write(keyInfo.KeyChar);
                        }
                        Console.WriteLine();
                    }
                    _stopEvent.Wait(1000);
                }
            }
        }
    }
