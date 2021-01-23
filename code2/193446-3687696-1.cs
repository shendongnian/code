    public static bool IsQuantized(this MeasurementCollection items)
    {
        if(items == null || items.Count == 0)
           return true;
        var valueToCompare = items.First().Template.Frequency;
        return items.All(i => i.Template.Frequency == valueToCompare);
    }
