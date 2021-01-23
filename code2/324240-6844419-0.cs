    if ((bool) child.GetCurrentPropertyValue(AutomationElementIdentifiers.IsLegacyIAccessiblePatternAvailableProperty)) {
        var pattern = ((LegacyIAccessiblePattern) child.GetCurrentPattern(LegacyIAccessiblePattern.Pattern));
        var state = pattern.GetIAccessible().accState;
    
        // Do something with state...
    }
