    public static MyAction ToMyAction(this SPListItem item)
    {
        return new MyAction  
           {  
              Title = item.GetSPFieldValue("Title"),  
              Description = item.GetSPFieldValue("Description"),  
              DeliveryOrderID = SPHelper.GetFirstLookupID(item.GetSPFieldValue("Delivery Order")),  
              EstimatedValue = ((item.GetSPFieldValue("Estimated Value") as double?) ?? 0),  
              AgreementTypeID = SPHelper.GetFirstLookupID(item.GetSPFieldValue("Contract Type"))                                                  
           };  
    }
    var action = result.GetSPListItems()
                       .Select(item => item.ToMyAction())
                       .FirstOrDefault();
    //var action = (from item in result.GetSPListItems()
    //              select item.ToMyAction()).FirstOrDefault();
