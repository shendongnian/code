    public class NameSplitter
    {
        // Added a property for returning splitName value thru' class
        private MemberName splitName;
        public MemberName SplitName
        {
            get { return splitName; }
            private set { splitName = value; }
        }
        public NameSplitter(string fullName)
        {
            nameInFull = fullName;
            SetAllowedTitles();
            SplitNamesAndRemovePeriods();
            SetTitles();
            
            splitName = new MemberName(titles, firstNames, lastNames);
        
           // return splitName; // Can't be done in a constructor and has to be returned via public property
        }
    }
