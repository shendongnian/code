    using System;
    using System.Timers;
    using System.Threading;
    
    public class ClassTask
    {
        System.Timers.Timer timer = null;
    
        public bool IsRunning { get; set; }
    
        public DateTime LastRunTime { get; set; }
    
        public bool IsLastRunSuccessful { get; set; }
    
        public double Interval { get; set; }
    
        public bool Stopped { get; set; }
    
        public ClassTask(double interval)
        {
            this.Interval = interval;
            this.Stopped = false;
            timer = new System.Timers.Timer(this.Interval);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }
        public void Start()
        {
            this.Stopped = false;
            this.StartTask();
        }
    
        public void Stop()
        {
            this.Stopped = true;
        }
    
        private void StartTask()
        {
            if (!this.Stopped)
            {
                //Thread thread = new Thread(new ThreadStart(Execute));
                //thread.Start();
                Execute();
            }
        }
    
        private void Execute()
        {
            try
            {
                this.IsRunning = true;
                this.LastRunTime = DateTime.Now;
                
                // Write code here
                this.IsLastRunSuccessful = true;
            }
            catch
            {
                this.IsLastRunSuccessful = false;
            }
            finally
            {
                this.IsRunning = false;
            }
        }
    
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.IsRunning)
                StartTask();
        }
    }
    using System;
    using System.Data;
    using System.Configuration;
    
    public class ClassTaskScheduler
    {
        ClassTask task = null;
    
        public ClassTaskScheduler()
        {
            this.task = new ClassTask(60000);
        }
    
        public void StartTask()
        {
            this.task.Start();
        }
    
        public void StopTask()
        {
            this.task.Stop();
        }
    }
