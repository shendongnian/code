    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Threading;
    
    namespace WorkerTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                WorkerGroup workerGroup = new WorkerGroup();
    
                Console.WriteLine("Starting...");
                
                for (int i = 0; i < 100; i++)
                {
                    var work = new Action(() => 
                    { 
                        Thread.Sleep(1000); //somework
                    });
    
                    workerGroup.AddWork(work);
                }
    
                while (workerGroup.WorkCount > 0)
                {
                    Console.WriteLine(workerGroup.WorkCount);
                    Thread.Sleep(1000);
                }
    
                Console.WriteLine("Fin");
    
                Console.ReadLine();
            }
        }
    
    
        public class WorkerGroup
        {
            private List<Worker> workers;
    
            private Queue<Action> workToDo;
    
            private object Lock = new object();
    
            public int WorkCount { get { return workToDo.Count; } }
    
            public WorkerGroup()
            {
                workers = new List<Worker>();
                workers.Add(new Worker());
                workers.Add(new Worker());
    
                foreach (var w in workers)
                {
                    w.WorkCompleted += (OnWorkCompleted);
                }
    
                workToDo = new Queue<Action>();
            }
    
            private void OnWorkCompleted(object sender, EventArgs e)
            {
                FindWork();
            }
    
            public void AddWork(Action work)
            {
                workToDo.Enqueue(work);
                FindWork();
            }
    
            private void FindWork()
            {
                lock (Lock)
                {
                    if (workToDo.Count > 0)
                    {
                        var availableWorker = workers.FirstOrDefault(x => !x.IsBusy);
                        if (availableWorker != null)
                        {
                            var work = workToDo.Dequeue();
                            availableWorker.StartWork(work);
                        }
                    }
                }
            }
        }
    
        public class Worker
        {
            private BackgroundWorker worker;
    
            private Action work;
    
            public bool IsBusy { get { return worker.IsBusy; } }
    
            public event EventHandler WorkCompleted;
    
            public Worker()
            {
                worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(OnWorkerDoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnWorkerRunWorkerCompleted);
            }
    
            private void OnWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (WorkCompleted != null)
                {
                    WorkCompleted(this, EventArgs.Empty);
                }
            }
    
            public void StartWork(Action work)
            {
                if (!IsBusy)
                {
                    this.work = work;
                    worker.RunWorkerAsync();
                }
                else
                {
                    throw new InvalidOperationException("Worker is busy");
                }
            }
    
            private void OnWorkerDoWork(object sender, DoWorkEventArgs e)
            {
                work.Invoke();
                work = null;
            }
        }
    }
