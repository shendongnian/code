    public ActionResult GetData(string userId, int version)
    {
        switch(version)
        {
            case 1:
                return GetDataV1(userId);
            case 2:
                return GetDataV2(userId);
            // You could always add more cases here as you get more versions, 
            // and still only have the one route
            default:
                // Probably more appropriate to return a result that contains error info,
                // but you get the idea
                throw new ArgumentOutOfRangeException("version");
        }
    }
    
    // Made these private since they are called from the public action
    private ActionResult GetDataV1(string userId)
    {
        // Do stuff one way
    }
    
    private ActionResult GetDataV2(string userId)
    {
        // Do stuff another way
    }
