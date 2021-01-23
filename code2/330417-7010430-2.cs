    public partial class ProgressWin : Window
    {
        // Add this to your class above in your question
        public event ProgressChangedEventHandler ProgressChanged;
        // Change or merge this with your existing function
        private void backgroundWorker1_ProgressChanged(object sender, ProjectChangedEventArgs e)
        {
            var temp = ProgressChanged;
            if(temp !=null)
                temp(this, e);
        }
    }
