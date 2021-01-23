    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
                 
    
            private void button1_Click(object sender, EventArgs e)
            {
                StartSync();
            }
    
            static bool SYNC_IN_PROGRESS;
    
            public void StartSync()
            {
                SYNC_IN_PROGRESS = false;
                System.Threading.Timer timer = new System.Threading.Timer(timerCallback, SYNC_IN_PROGRESS, 0, 1000); 
    
                
            }
    
            public void timerCallback(Object stateInfo)
            {
                Debug.WriteLine("Sync?");
    
                if (!(bool)stateInfo)
                {
                    SYNC_IN_PROGRESS = true;
    
                    Thread thSync = new Thread(new ThreadStart(sync));
                    thSync.Start();
                }
            }
    
            void sync()
            {
                Debug.WriteLine("Syncing...");
                SYNC_IN_PROGRESS = false;
            }
        }
