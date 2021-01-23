    public void SplitNamesAndRemovePeriods()
    {
        nameInFull = nameInFull.Replace(".", String.Empty);
        string[] allNames = nameInFull.Split(' ');
        PrintNames();
    }
