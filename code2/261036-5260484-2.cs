    private readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
    
    int counter = 0;
    private void timer1_Tick(object sender, EventArgs e) 
    {
        if (Locker.TryEnterWriteLock(0))
        {
            try
            {
                MessageBox.Show("Hello");
                Counter++;
                if (Counter == 10)
                {
                    Timer.Enabled = false;
                }
            }
            catch { }
            finally
            {
                Locker.ExitWriteLock();
            }
        }
    }
