    private void backgroundCopy_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
    	try
    	{
    		Cursor.Current = Cursors.WaitCursor;
    		//DO WORK
    		// Set Progress Bar to Green
    		progressBar1.SetState(1);
    		//...
    	}
    	finally
    	{
    		Cursor.Current = Cursors.Default;
    	}
    }
