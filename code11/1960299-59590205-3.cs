        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            watcher1.EnableRaisingEvents = true;
            watcher2.EnableRaisingEvents = true;
            watcher3.EnableRaisingEvents = true;
        }
        protected override void OnStop()
        {
            base.OnStop();
            watcher1.EnableRaisingEvents = false;
            watcher2.EnableRaisingEvents = false;
            watcher3.EnableRaisingEvents = false;
        }
