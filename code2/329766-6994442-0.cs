    private void button1_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            MessageBox.Show("Hello There!");
        }) { IsBackground = true }.Start();
    
        Thread.Sleep(1000);
        if (MessageBox.Show(this, "Hi", "Jalal", MessageBoxButtons.YesNo) == 
            System.Windows.Forms.DialogResult.Yes)
        {
            return;
        }
    }
