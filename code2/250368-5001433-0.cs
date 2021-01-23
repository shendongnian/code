    public bool IsDateValid(DateTime toDate)
    {
        // just guessing on the rules here...
        return (Manager.MaxToDate >= toDate.Year);
    }
