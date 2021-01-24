    using System;
    using System.Linq;
    using System.Timers;
    namespace actionexample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Func<string, string> task = (s) =>
                {
                    return new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
                };
                var taskRunner = new TaskAgent(task, "sample");
                taskRunner.ResultReady += (s, e) => Console.WriteLine(e);
                taskRunner.Run();
                Console.ReadLine();
                taskRunner.Dispose();
            }
        }
        public class TaskAgent : IDisposable
        {
            Timer timer;
            Func<string, string> task;
            string input;
            public event EventHandler<string> ResultReady;
            public TaskAgent(Func<string, string> task, string input)
            {
                this.task = task;
                this.input = input;
                this.timer = new Timer() { AutoReset = true, Interval = 1000 };
                this.timer.Enabled = false;
                this.timer.Elapsed += (s, e) =>
                {
                    var result = task(input);
                    ResultReady?.Invoke(this, result);
                };
            }
            public void Run() { timer.Start(); }
            public void Dispose() { timer.Dispose(); }
        }
    }
