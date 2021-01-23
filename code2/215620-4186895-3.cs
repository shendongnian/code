    ContractAction targetAction = new ContractAction();
    var item = (from listItem in result.GetSPListItems()
                select new ContractAction
                {
                    Title = listItem.GetSPFieldValue("Title"),
                    Description = listItem.GetSPFieldValue("Description"),
                    DeliveryOrderID = SPHelper.GetFirstLookupID(listItem.GetSPFieldValue("Delivery Order")),
                    EstimatedValue = ((listItem.GetSPFieldValue("Estimated Value") as double?) ?? 0),
                    AgreementTypeID = SPHelper.GetFirstLookupID(listItem.GetSPFieldValue("Contract Type")),                                                
                }).SelectFirstInto(targetAction);
