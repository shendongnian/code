    void DoSomething()
    {
        if (richTextBox1.InvokeRequired)
            richTextBox1.Invoke(new MethodInvoker(DoSomething));
        else
        {
            richTextBox1.BackColor = Color.Cyan;
            // Here should go everything the method will do.
        }
    }
