    public NameSplitter(string fullName)
        {
            nameInFull = fullName;
            SetAllowedTitles();
            SplitNamesAndRemovePeriods();
            SetTitles();
            MemberName splitName = new MemberName(titles, firstNames, lastNames);
            return splitName; // How would a constructor return something?
        }
