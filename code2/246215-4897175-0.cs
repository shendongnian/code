    try
    {
        string data = Read(txtLocation.Text);
        txtInfo.Text = data;
    }
    catch (FileNotFoundException ex)
    {
        string log = String.Format("[{0}] Couldn't find the path: {1}"
                                  , DateTime.Now
                                  , ex.FileName);
        WriteLog(log);
    }
