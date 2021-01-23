    private static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!String.IsNullOrEmpty(e.Data))
        {
           _textBox.InvokeIfRequired( c => c.Text += e.Data );       
        }
    }
