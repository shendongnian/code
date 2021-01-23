    try
    {
     con.Open();
    }
    catch(Exception ex)
    {
    if(con.State== ConnectionState.Open)
    con.Close();
    }
    finally
    {
    con.Close();
    }
