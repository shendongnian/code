    public void SplitNamesAndRemovePeriods()
        {
            nameInFull = nameInFull.Replace(".", "");
            string[] allNames = nameInFull.Split(' ');
            PrintNames();
        }
