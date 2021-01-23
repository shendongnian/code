    private readonly object _userActivityLocker = new object();
    
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        new Thread(delegate()
        {
        if (System.Threading.Monitor.TryEnter(_userActivityLocker))
        {
            //note that any sub clicks will be ignored while we are here
            try
            {
                //here it is safe to call the save and you can disable the btn
            }
            finally
            {
                System.Threading.Monitor.Exit(_userActivityLocker);
                //re-enable the btn if you disable it.
            }
        }
        }) { IsBackground = true }.Start();
    }
