    private static readonly object LockerObject = new object();
    
    int counter = 0;
    private void timer1_Tick(object sender, EventArgs e) 
    {
        if (Monitor.TryEnter(LockerObject))
        {
            try
            {
                MessageBox.Show("Hello"); 
                counter++; 
                if (counter == 10)
                {
                    timer1.Enabled = false;
                }
            }
            catch { }
            finally
            {
                Monitor.Exit(LockerObject);
            }
        } 
    }
