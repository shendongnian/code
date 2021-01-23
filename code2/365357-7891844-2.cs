    try
    {
       connection.Open();
       ... 
    }
    catch (Exception e)
    {
        // at least one of these..
        Console.WriteLine(e);
        MessageBox.Show(e);
        Debug.WriteLine(e);
    }
