    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (invokeInProgress)
        {
            e.Cancel = true;  // cancel the original event 
     
            stopInvoking = true; // advise to stop taking new work
     
            // now wait until current invoke finishes
            await Task.Factory.StartNew(() =>
                            {
                                while (invokeInProgress);  
                            });
     
            // now close the form
            this.Close();
        }
    }
