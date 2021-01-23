    FindObject()
    {
    //no need to throw an exception, let it bubble.
    }
    
    IsUser
    {
    try{...a.FindObject("Id = 1",""); return true;}
    catch(Exception ex){Log(ex); return false;}
    }
