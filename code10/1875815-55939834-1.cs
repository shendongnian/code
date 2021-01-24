        // a for loop does nothing if there are no items in the collection
        if(acordPolicy.OLifEExtension).Any()
        {
            
            // no loop - we just take the first item.
            var OlifeExt = acordPolicy.First(); 
            var elements = new List<XmlElement>();
            foreach (var ele in OlifeExt.Any)
            {
                if (ele.Name == "AllocationRestrictions")
                {
                    var allocationRestrictionElement = acordPolicy.OLifEExtension[0]["AllocationRestrictions"];
                    return allocationRestrictionElement.AsAllocationRuleList();
                }
            }
        }
        return null;
    
