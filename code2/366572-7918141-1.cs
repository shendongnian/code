    public List<MyEntity> GetData<MyEntity>(int product_id) where T : class 
    {
        List<MyEntity> myList = new List<MyEntity>(); 
        var groupData = context.ExecuteStoreQuery<MyEntity>("exec 
        spGetProductsByGroup @ProductID={0}", product_id);
        return myList;
    }
