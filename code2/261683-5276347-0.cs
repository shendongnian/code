    public class SomeClass
    {
        private BackgroundWorker _myFunctionBackgroundWorker;
    	private SomeProgressBar pb;
    	
    	public SomeClass()
    	{
    		_myFunctionBackgroundWorker = new BackgroundWorker();
    		_myFunctionBackgroundWorker.DoWork += myFunctionBackgroundWorker_DoWork;
    		_myFunctionBackgroundWorker.RunWorkerCompleted += myFunctionBackgroundWorker_RunWorkerCompleted;
    
    		pb.visible = true;
    		_myFunctionBackgroundWorker.RunWorkerAsync();
    	}
    	
        private void myFunctionBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
    		runMyfunction();
        }
    
    
        private void myFunctionBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
    		pb.visible = false;
        }
    }
