    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        this.Invoke((MethodInvoker)delegate ()
        {
            string text = metroComboBox1.Text;
            if (metroComboBox1.SelectedItem == "TITLE") 
            {
               //some code here
            }
        });        
    }
