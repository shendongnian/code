    public static void SelectFirstInto(this IEnumerable<ContractAction> items, ContractAction target)
    {
        var source = items.FirstOrDefault();
    
        if(source != null)
        {
            target.Title = source.Title,  
            target.Description = source.Description ,  
            target.DeliveryOrderID = source.DeliveryOrderID,  
            target.EstimatedValue = source.EstimatedValue, 
            target.AgreementTypeID = source.AgreementTypeID                                                 
         }
    }
