    Datetime? Egresstime ;
    
    DateTime timeOut;
    if(!DateTime.TryParse(rdr["timeOut"], out timeOut))
    {
        Egresstime  = null;
    }
    If(Egresstime ==null)
    {
    //print still logged in
    }
