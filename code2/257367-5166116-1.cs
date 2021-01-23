    private void Calls_Calls_MouseUp(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            DoSomething();
        }
    }
    private void DoSomething()
    {
        ThreadPool.QueueUserWorkItem(state => {
           // do the work here
        });
    }
