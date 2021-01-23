    private void button1_Click(object sender, EventArgs e)
    {
        _Class1.Start();
        Thread.Sleep(1000);
        MessageBox.Show(_Class1.GetMessage());
    }
