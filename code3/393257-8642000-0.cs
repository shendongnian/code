    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            using (EventProducer producer = new EventProducer(TimeSpan.FromMilliseconds(250.0d)))
            using (EventConsumer consumer = new EventConsumer(producer, TimeSpan.FromSeconds(1.0d)))
            {
                Console.WriteLine("Press ENTER to stop.");
                Console.ReadLine();
            }
            Console.WriteLine("Done.");
        }
        private static class ConsoleLogger
        {
            public static void WriteLine(string message)
            {
                Console.WriteLine(
                    "[{0}]({1}) {2}",
                    DateTime.Now.ToString("hh:mm:ss.fff", CultureInfo.InvariantCulture),
                    Thread.CurrentThread.ManagedThreadId,
                    message);
            }
        }
        private sealed class EventConsumer : IDisposable
        {
            private readonly CriticalSectionSlim criticalSection;
            private readonly EventProducer producer;
            private readonly TimeSpan processingTime;
            
            private Task currentTask;
            public EventConsumer(EventProducer producer, TimeSpan processingTime)
            {
                if (producer == null)
                {
                    throw new ArgumentNullException("producer");
                }
                if (processingTime < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("processingTime");
                }
                this.processingTime = processingTime;
                this.criticalSection = new CriticalSectionSlim();
                this.producer = producer;
                this.producer.SomethingHappened += this.OnSomethingHappened;
            }
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.producer.SomethingHappened -= this.OnSomethingHappened;
                }
            }
            private void OnSomethingHappened(object sender, EventArgs e)
            {
                if (this.criticalSection.TryEnter())
                {
                    try
                    {
                        this.StartTask();
                    }
                    catch (Exception)
                    {
                        this.criticalSection.Exit();
                        throw;
                    }
                }
            }
            private void StartTask()
            {
                if (this.currentTask != null)
                {
                    this.currentTask.Wait();
                }
                this.currentTask = Task.Factory.StartNew(this.OnSomethingHappenedTask);
            }
            private void OnSomethingHappenedTask()
            {
                try
                {
                    this.OnSomethingHappenedImpl();
                }
                finally
                {
                    this.criticalSection.Exit();
                }
            }
            private void OnSomethingHappenedImpl()
            {
                ConsoleLogger.WriteLine("BEGIN: Consumer processing.");
                Thread.CurrentThread.Join(this.processingTime);
                ConsoleLogger.WriteLine("END:   Consumer processing.");
                throw new Exception("haw");
            }
        }
        private sealed class EventProducer : IDisposable
        {
            private readonly TimeSpan timeBetweenEvents;
            private readonly Thread thread;
            private volatile bool shouldStop;
            public EventProducer(TimeSpan timeBetweenEvents)
            {
                if (timeBetweenEvents < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("timeBetweenEvents");
                }
                this.timeBetweenEvents = timeBetweenEvents;
                this.thread = new Thread(this.Run);
                this.thread.Start();
            }
            public event EventHandler SomethingHappened;
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.shouldStop = true;
                    this.thread.Join();
                }
            }
            private void Run()
            {
                while (!shouldStop)
                {
                    this.RaiseEvent();
                    Thread.CurrentThread.Join(this.timeBetweenEvents);
                }
            }
            private void RaiseEvent()
            {
                EventHandler handler = this.SomethingHappened;
                if (handler != null)
                {
                    ConsoleLogger.WriteLine("Producer is raising event.");
                    handler(this, EventArgs.Empty);
                }
            }
        }
        private sealed class CriticalSectionSlim
        {
            private int active;
            public CriticalSectionSlim()
            {
            }
            public bool TryEnter()
            {
                return Interlocked.CompareExchange(ref this.active, 1, 0) == 0;
            }
            public void Exit()
            {
                Interlocked.Exchange(ref this.active, 0);
            }
        }
    }
