    // file "Program.cs"
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace ProgressDialog
    {
        static class Program
        {
            [STAThread] static void Main()
            {
                // build UI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var rootForm = new Form { Text = @"Test Form", Width = 300, Height = 100 };
                var btn = new Button { Text = @"Start", Parent = rootForm, Dock = DockStyle.Top };
                var progress = new ProgressBar { Minimum = 0, Parent = rootForm, Dock = DockStyle.Top, Style = ProgressBarStyle.Continuous };
                new Label { Text = @"Progress:", Parent = rootForm, Dock = DockStyle.Top, AutoSize = true };
                // define parameters
                const int sourcesCount = 20; // how many sources do we want to process
                var completedCount = 0;
                var randomGenerator = new Random();
                var timer = new Stopwatch();
                // callback that will be invoked on UI thread each time a task finishes
                Action<int> onTaskCompleted = source =>
                {
                    ++completedCount; // we're modifying "completedCount" closure on purpose
                    progress.Value = completedCount;
                    System.Diagnostics.Debugger.Log(0, null, string.Concat(@"UI notified that task for source ", source, @" finished; overall ", completedCount, @" tasks finished", Environment.NewLine));
                    if (completedCount == sourcesCount)
                    {
                        timer.Stop();
                        btn.Enabled = true;
                        btn.Text = string.Concat(@"Finished (took ", timer.ElapsedMilliseconds, @" milliseconds). Start again");
                    }
                };
                // task itself (the hard part :) )
                Action<int> task = source =>
                {
                    System.Diagnostics.Debugger.Log(0, null, string.Concat(@"  > Starting task for source ", source, Environment.NewLine));
                    Thread.Sleep(randomGenerator.Next(100, 200)); // simulate some workload (taking between 100 and 200 milliseconds)
                    System.Diagnostics.Debugger.Log(0, null, string.Concat(@"  < Finished task for source ", source, Environment.NewLine));
                    rootForm.BeginInvoke(new Action(() => onTaskCompleted(source)));
                };
                // start button handler (kick-starts the background tasks)
                btn.Click += (src, args) =>
                {
                    btn.Enabled = false;
                    btn.Text = @"Running...";
                    progress.Maximum = sourcesCount;
                    progress.Value = 0;
                    timer.Restart();
                    completedCount = 0;
                    var sources = Enumerable.Range(1, sourcesCount); // simulate getting data for each task
                    var tasks = sources
                        .Select(s => Task.Factory.StartNew(() => task(s))) // at this point we only have an enumerable that is able to start all the tasks, nothing is running yet
                        .ToArray(); // now the tasks are started
                    if (tasks.Length != sourcesCount) { throw new InvalidOperationException(); } // assert that we created one task for each source
                };
                // show the form now, let the user interact with it
                Application.Run(rootForm);
            }
        }
    }
