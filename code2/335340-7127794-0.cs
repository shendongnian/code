    using System.Threading;
    private volatile bool _requestStop = false;
    private readonly object _oneExecuteLocker = new object();    
    private void OnButton1Click(ojbect sender, EventArgs e)
    {
        new Thread(() =>
        {
            if (Monitor.TryEnter(_oneExecuteLocker))
            {//if we are here that is means the code is not already running..
                try
                {
                    while (!_requestStop)
                    {
                        //DoStuff
                    } 
                }
                finally
                {
                    Monitor.Exit(_oneExecuteLocker);
                }
            }
        }){ IsBackground = true }.Start();
    }
    
    private void OnButton2Click(object sender, EventArgs e)
    {
        _requestStop = true;
    }
