    // class NameSplitter
    public NameSplitter(string fullName)
        {
            nameInFull = fullName;
            SetAllowedTitles();
            SplitNamesAndRemovePeriods();
            SetTitles();
            //MemberName splitName = new MemberName(titles, firstNames, lastNames);
            //return splitName;
        }
    
    public MemberName MemberName   // readonly property
    {
        get { return new MemberName(titles, firstNames, lastNames); }
    }
