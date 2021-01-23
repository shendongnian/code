    try
    {
        // run inser or update query here
        myObj.InserRow();
    }
    catch (System.Data.SqlClient.SqlException ex)
    {
        if (ex.Number == 2601)
        {
            //"duplicate entry found!";
        }
        else
        {
            // some other kind of sql related exception
        }
    }
    catch (Exception ex)
    {
        // any other exception
    }
 
