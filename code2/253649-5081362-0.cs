    catch (PermissionDeniedException ex)
    {
        Log(ex.foo);
        ShowMessageToUser(ex.Message); 
    }
    catch(Exception ex)
    {
        ShowMessageToUser(ex.Message); 
    }
