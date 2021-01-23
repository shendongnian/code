    using System.Windows.Threading;
    private void Run()
    {
        try
        {
            var t = new Thread(Read) { IsBackground = true };
            t.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void Read()
    {
        foreach (/* whatever you are looping through */)
        {
            /* I recommend creating a class for the result use that for the 
               datagrid filling. */
            var sr = new ResultClass()
            /* do all you code to generate your results */
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, 
                                   (ThreadStart)(() => dgResults.AddItem(sr)));   
        }    
    }
