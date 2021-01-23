    void rinxProcess_Exited(object sender, EventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke((Action)(() => ProcessExited()));
            return;
        }
    
        ProcessExited();
    }
    
    private void ProcessExited()
    {
        tabPage_buttonStartExtraction.Enabled = true;
        tabPageExtraction_StopExtractionBtn.Enabled = false;
    }
