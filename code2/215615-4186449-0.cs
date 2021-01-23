    var item = (from listItem in result.GetSPListItems()
            from query2Outer in result.SecondQuery().Where(x => x.ItemEdp == it.ItemEdp).DefaultIfEmpty() // This is an outer join
            select new Action
            {
                //if the one query didn't return an item then it sets the properties to the default values
                Example = (query2Outer == null ? "Default Value" : query2Outer.Example),
                Title = listItem.GetSPFieldValue("Title"),
                Description = listItem.GetSPFieldValue("Description"),
                DeliveryOrderID = SPHelper.GetFirstLookupID(listItem.GetSPFieldValue("Delivery Order")),
                EstimatedValue = ((listItem.GetSPFieldValue("Estimated Value") as double?) ?? 0),
                AgreementTypeID = SPHelper.GetFirstLookupID(listItem.GetSPFieldValue("Contract Type")),                                                
            }).FirstOrDefault();
