    private void button1_Click(object sender, EventArgs e)
    {
        ThreadStart s = () =>
        {
            for (int i = 0; i <= 10; i++)
            {
                Action a = () => progressBar1.Value = i * 10;
                BeginInvoke(a);
                Thread.Sleep(300); // imitate some workload
            }
        };
        var t = new Thread(s);
        t.Start();
    }
