    public void InitTimer()
    {
        for (int i = 0; i < 10; i++)
        {
            System.Threading.Thread.Sleep(2000);
            MessageBox.Show("test");
        }
    }
