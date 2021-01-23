    int status = 0;
    private bool IsRunning = false;
        public Form1()
        {
            InitializeComponent();
            StartAnimation();
        }
        public void StartAnimation()
        {
            backgroundWorker1.WorkerReportsProgress = false;
            backgroundWorker1.WorkerSupportsCancellation = true;
            IsRunning = true;
            backgroundWorker1.RunWorkerAsync();
        }
       
        public void StopAnimation()
        {
            backgroundWorker1.CancelAsync();
        }
        delegate void UpdatingThreadAnimation();
        public void UpdateAnimationFromThread()
        {
            try
            {
                if (label1.InvokeRequired == false)
                {
                    UpdateAnimation();
                }
                else
                {
                    UpdatingThreadAnimation d = new UpdatingThreadAnimation(UpdateAnimationFromThread);
                    this.Invoke(d, new object[] { });
                }
            }
            catch(Exception e)
            {
            }
        }
     private void UpdateAnimation()
        {
        if(status ==0) 
        {
        // mypicture.image = image1
         }else if(status ==1)
         {
        // mypicture.image = image2
         }
        //doing as much as needed
 
          status++;
            if(status>1) //change here if you have more image, the idea is to set a cycle of images
            {
                status = 0;
            }
            this.Refresh();
        }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (IsRunning == true)
            {
                System.Threading.Thread.Sleep(100);
                UpdateAnimationFromThread();
            }
        }
 
