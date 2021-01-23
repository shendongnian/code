    public partial class Form1 : Form
    {
        string strProvider;
        MySqlConnection sqlConn;
        MySqlCommand command;
        MySqlDataReader Reader;
    
        Thread workerThread;
    	ManualResetEvent manualReset;
    
        public Form1()
        {
            InitializeComponent();
            initializedb();
            workerThread = new Thread(shows);
            workerThread.Start();
            workerThread.IsBackground = true;
    		manualReset = new ManualResetEvent(true); // true for allow running
    	}
    
        public void shows()
        {
            string k;
    
            command.CommandText = "SELECT * FROM imageframe1";
            sqlConn.Open();
            Reader = command.ExecuteReader();
    
            while (Reader.Read())
            {
                k = (string)(Reader.GetValue(1));
                pictureBox1.Image = Image.FromFile(k);
                Thread.Sleep(3000);
    			manualReset.WaitOne(); // wait if reset
            }
    
            sqlConn.Close();
    
            stopthread();
        }
    
        public void pauseThread()
        {
    		manualReset.ReSet();
        }
    
    	public void continueThread()
    	{
    		manualReset.Set();
    	}
    }
