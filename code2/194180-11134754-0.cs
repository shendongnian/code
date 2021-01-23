    int id;
    
    try
    {
     id = Convert.toInt32(ta.InsertQuery(firstName, lastName, description));
    }
    catch (SQLException ex)
    {
    //...
    }
    finally
    {
    //...
    }
