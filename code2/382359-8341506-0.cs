    class ThreadCreator
    {
        private AnObject obj = new AnObject();
        public ThreadCreator()
        {
            for (int i = 0; i < 100; ++i)
            {
                ThingToThread th = new ThingToThread();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += th.DoWork;
                worker.ProgressChanged += WorkerProgressChanged;
				worker.RunWorkerAsync();
            }
        }
        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
			string stuff = e.UserState as string;
			obj.DoThing(stuff);
        }
    }
