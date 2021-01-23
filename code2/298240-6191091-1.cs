    var user = new DirectoryEntry("", username, password)
    try 
    {
        user.RefreshCache();
        /* Check group membership */
    }
    catch (DirectoryServicesCOMException ex)
    {
        /* Invalid username/password */
    }
    finally
    {
        user.Close();
    }    
