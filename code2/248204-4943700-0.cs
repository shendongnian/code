    public void countToLots()
    {
        for (int i = 0; i < 10000000; i++)
        {
            // running on bg thread
            textBox1.Invoke((MethodInvoker) delegate {
                // running on UI thread
                textBox1.Text = "Counting to 10000000, value is "
                          + i + Environment.NewLine;
            });
            // running on bg thread again
        }
    }
