    [System.Serializable] // Makes it so you can view this classes data members in the inspector, so you should see your public list now.
    public class DiaEntryClass
    {
        public string line;
        public string location;
        public string character;
    
        public DiaEntryClass(string inLine, string inLocation, string inCharacter)
        {
            // Actually setting my variables to the values passed in...
            line = inLine;
            location = inLocation;
            character = inCharacter;
        }
    }
