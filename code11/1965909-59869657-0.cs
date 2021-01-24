    var _error = null;
    var child = RootDB.Child(_node);
    
    try
    {
        var result = await child.GetValueAsync();
    
        Debug.Log(_node + "| is Completed");
        DataSnapshot _snapShot = result;
        if (_snapShot.Exists == true)
        {
            // Get the value _snapShot.GetRawJsonValue();
        }
        else
        {
            Debug.Log("Snapshot DOES NOT Exist for " + _node);
        }
    
    }
    catch (OperationCanceledException ex)
    {
        Debug.Log(_node + " | is canceled ");
    }
    catch (Exception ex)
    {
        Debug.Log("Exception Found in " + _node + " | " + ex.Message);
        _error = CloudErrorHandle.DatabaseErrorMessageFor(ex.InnerExceptions);
    }
