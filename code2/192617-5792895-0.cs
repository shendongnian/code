        public delegate void SucceedDelegate();
        // calling by ThreadPool.QueueUserWorkItem(succeed);
        protected void succeed(Object obj){
            Application.OpenForms[0].Invoke(new SucceedDelegate(succeed0));
        }
        private void succeed0()
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += succeedHandler;
            timer.Start();
        }
        private void succeedHandler(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            succeed00();
        }
        private void succeed00()
        {
            //call WebBrowser.Dispose() here
        }
