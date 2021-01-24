    [HttpPost]
    private  IActionResult Stock([FromBody] List<spGetNewStockCountHeader_Result> jsonvalues)    
    {
      ObjectParameter TransactionId = new ObjectParameter("TransactionId", typeof(Int32));
      foreach (spGetNewStockCountHeader_Result Datastock in jsonvalues)
      {
        
        spGetNewStockCountHeader_Result Stockobject = new spGetNewStockCountHeader_Result();
        Stockobject.UserID = Datastock.UserID;
        Stockobject.created = Datastock.created;
        Stockobject.CompanyID = Datastock.CompanyID;
        Stockobject.modified = Datastock.modified;
        Stockobject.modifieduserid = Datastock.modifieduserid;
        Stockobject.confirm = Datastock.confirm;
        Stockobject.ShopId = Datastock.ShopId;
        enqentities.spGetNewStockCountHeader(Datastock.UserID, Datastock.created, Datastock.CompanyID, Datastock.modified, Datastock.modifieduserid, Datastock.confirm,Datastock.ShopId, TransactionId);
      }
    return Ok(new { data = TransactionId.Value});    
    }
