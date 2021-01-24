public static AllocationRuleList AsAllocationRuleList(this SIGACORD.Policy acordPolicy)
    {
        foreach (var OlifeExt in acordPolicy.OLifEExtension)
        {
            var restrictions = OlifeExt.FirstOrDefault(f => f.Name == "AllocationRestrictions");
            if (restrictions == null) continue;
            return restrictions.AsAllocationRuleList();
        }
        return null;
    }
