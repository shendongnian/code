    //just grab the first item
    var item = result.GetSPListItems().FirstOrDefault();
    
    //then grab the properties into the existing ContractActionEntity                             
    contractAction.Title = item.GetSPFieldValue("Title");
    contractAction.Description = item.GetSPFieldValue("Description");
    contractAction.DeliveryOrderID = SPHelper.GetFirstLookupID(item.GetSPFieldValue("Delivery Order"));
    contractAction.EstimatedValue = item.GetSPFieldValue("Estimated Value").ToNullableDouble();
    contractAction.AgreementTypeID = SPHelper.GetFirstLookupID(item.GetSPFieldValue("Contract Type")),
