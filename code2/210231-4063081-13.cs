    delegate void ColorChanger(Color c);
    
    void DoSomething(Color c)
    {
        if (richTextBox1.InvokeRequired)
            richTextBox1.Invoke(new ColorChanger(DoSomething), c);
        else
        {
            richTextBox1.BackColor = c;
            // Here should go everything the method will do.
        }
    }
