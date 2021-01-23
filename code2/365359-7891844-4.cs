    try
    {
       connection.Open();
       ... 
    }
    //catch (Exception e)
    catch (SqlException e)
    {
        // at least one of these..
        Console.WriteLine(e);
        MessageBox.Show(e);
        Debug.WriteLine(e);
        var inner = e.InnerException;
        while (inner != null)
        {
             //display / log / view
             inner = inner.InnerException;
        }
    }
