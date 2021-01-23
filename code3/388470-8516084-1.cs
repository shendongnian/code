    void test()
    {
        for (int i = 60; i >= 1; i--)
        {
            Thread.Sleep(1000);
            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action(()  => {
                    label1.Text = i.ToString();
                     
                }));
                        
            }
        }
    }
