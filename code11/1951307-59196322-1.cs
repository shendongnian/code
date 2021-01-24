        protected override void OnStart(string[] args)
        { 
            WriteToFile("started open " + DateTime.Now);
            System.Diagnostics.Debugger.Launch();
            timer.Interval = 10000; //number in milisecinds
            timer.Elapsed += new ElapsedEventHandler(ChangeResumeformat);
            timer.Enabled = true;
        }
