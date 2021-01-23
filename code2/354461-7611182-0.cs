    public partial class MyForm : Form
    {
        Thread _workerThread;
    
        public MyForm()
        {
            _workerThread = new Thread(Calculate);
        }
    
        public void StartCalc()
        {
            _workerThread.Start();
        }
    
        public void Calculate()
        {
            //call singleton here
    
    
        }
    
        // true if user are allowed to change calc settings
        public bool CanUpdateSettings
        {
            get { return !_workerThread.IsAlive; } }
        }
    }
