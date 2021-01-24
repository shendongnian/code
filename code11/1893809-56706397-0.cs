    DateTime? startDate;
    DateTime? endDate;
    
    if (startDate.HasValue && endDate.HasValue)
    {
        return (startDate.Value - endDate.Value).TotalDays;
    }
    else
    {
        // handle one or more dates being null
    }
