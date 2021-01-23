    SqlDataReader dr = null;
    try
    {
        //connect to db etc
        dr = DbHelper.GetReader("sp_GetCustomer", param);
        if (!dr.HasRows)
        {
    
        }
    }
    catch
    {
    //show an error message
    }
    
