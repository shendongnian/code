    private readonly object _userActivityLocker = new object();
    private void button1_Click(object sender, EventArgs e)
    {
        new Thread(delegate()
        {
        if (System.Threading.Monitor.TryEnter(_userActivityLocker))
        {
            //note that any sub clicks will be ignored while we are here
            try
            {
                //here execute your long running operation without blocking the UI
            }
            finally
            {
                System.Threading.Monitor.Exit(_userActivityLocker);
            }
        }
        }) { IsBackground = true }.Start();
    }
