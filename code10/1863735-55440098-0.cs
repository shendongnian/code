    //getting list of data from DAL, result is IEnumerable<First> or similar (List etc)
    var Hitory = _objHitoryDB.GetHitoryId(Id);
    
    //Declare List<Second> variable where we will store result of mapped data
    List<Second> HitoryList = null;
    
    //Map First-objects to Second objects with Linq Select: 
    HitoryList = ((List<Second>)Hitory.Select(
        x => new Second()
        {
          imID = x.imID,
          Title = x.Title,
          Desc = x.Desc,
          CreatedOn= x.CreatedOn
        }).ToList();
