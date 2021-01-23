    try
    {
        unitOfWork.BeginTransaction();
        // some code
        var isSomething = IsSomeThing()
    }
    catch(Exception ex)
    { 
       unitOfWork.RollBack();
    }
    finally
    {
        unitOfWork.Commit();
    }
    
