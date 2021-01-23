    string ErrorMessage = "";
    void bgw_DoWork(object sender, DoWorkEventArgs ea)
    {
        //some variable declarations and initialization
        try
        {
            //do some odbc querying
            ErrorMessage = "";
        }
        catch (Exception ex)
        {
            //stuff..
            ErrorMessage = ex.Message;
        }
    }
    
    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null || !string.IsNullOrEmpty(ErrorMessage))
        {
            //do something
            MessageBox.Show(ErrorMessage);
        }
        else
        {
            //do something else
        }
    }
