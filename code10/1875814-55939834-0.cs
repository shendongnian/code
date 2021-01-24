        if(acordPolicy.OLifEExtension).Any()
        {
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
    
