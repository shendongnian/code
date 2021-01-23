    public partial class MainForm:Form
    {
       LoadingScreen ls;
    
       public MainForm()
       {
       }
    
       public void StartLoad()
       {
          ls = new LoadingScreen(this.timerStart);
          backgroundWorker.RunWorkerAsync();
          ls.Show();
       }
    
       void backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
       {
          //Loading code goes here
       }
    
       void BackgroundWorkerMainRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
          if(ls != null)
             ls.Close();
       }
    }
