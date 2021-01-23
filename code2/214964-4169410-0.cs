    try
    {
        try
        {
            if(UserWantsTo())
                CopyFile();
            else
                throw new Exception("User doesn't want Copy1");
        }
        catch(Exception Copy1Ex)
        {
            throw Copy1Ex;
        }
        // repeat as many file-copies here.
    }
    catch (Exception OuterException)
    {
        MessageBox.Show("One of the file copy operations failed: " + OuterException.ToString());
    }
