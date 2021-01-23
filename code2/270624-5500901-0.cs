    //Server
    public void GetCommission(object oLoc) //or GetCommission(DTContract[] Loc)
    {
    List<BOLibrary.Flight.DTContract> Loc = oLoc as List<BOLibrary.Flight.DTContract>();
    
    ...
    }
    
    //Client
    service.GetCommission(loc1 as object);
