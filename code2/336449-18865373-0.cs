    class MyClassWithDelegates
    {
        public delegate void ProgressDelegate( int progress );
        public ProgressDelegate myProgress;
        public void MyProgress(int progress)
        {
             myTextbox.Text = ..... ; // this is code that must be run in the GUI thread.
        }
        public MyClassWithDelegates()
        {
          myProgress = new ProgressDelegate(MyProgress);    
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Invoke( myProgress, e.ProgressPercentage );
        }
    }
