    try
    {
        //if the value is coming back as string
        int value1 = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
        //if the value is already an integer
        int value2 = (int)ds.Tables[0].Rows[0][0];
    }
    catch(Exception ex)
    {
        throw new Exception("You do not have even a single value in the DataSet or its not an integer!", ex);
    }
