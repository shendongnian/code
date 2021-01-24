    public string GetStock([FromUri] StockRequestModel model)
    {
        if ( !ModelState.IsValid )
        {
             some code here
        } 
    
        //at this point your model is valid and you have IDs so can proceed with your code
    }
