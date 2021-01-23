    public class YourForm
    {
        public YourForm
        {
            Class2 yourClass2Instance = new Class2();
            class2.ProgressEvent += ProgressEventHandler;
        }
    
        private void PorgressEventHandler(object sender, ProgressEventArgs e)
        {
           progressbar.value += e.Progress;
        }
    
    }
    
