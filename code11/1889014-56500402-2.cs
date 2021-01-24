    private void myProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Process myProcess = sender as Process;
        if (myProcess == null)
            return;
        cmd_output_text.Invoke(new Action (delegate { cmd_output_text.AppendText("\n"+e.Data); }));
    }
