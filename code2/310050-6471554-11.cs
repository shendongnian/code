    public class YourForm
    {
        public YourForm
        {
            Class2 yourClass2Instance = new Class2();
            yourClass2Instance.ProgressEvent += ProgressEventHandler;
        }
    
        private void ProgressEventHandler(object sender, ProgressEventArgs e)
        {
           progressbar.Value += e.Progress;
        }
    
    }
    
