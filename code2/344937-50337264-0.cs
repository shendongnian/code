    public static class StateArray
    {
        public static List<(string Abbreviation, string Name)> States { get; }
        static StateArray()
        {
            States = new List<(string, string)>(50);
            States.Add(("AL", "Alabama"));
            States.Add(("AK", "Alaska"));
            States.Add(("AZ", "Arizona"));
            States.Add(("AR", "Arkansas"));
            States.Add(("CA", "California"));
            States.Add(("CO", "Colorado"));
            States.Add(("CT", "Connecticut"));
            States.Add(("DE", "Delaware"));
            States.Add(("DC", "District Of Columbia"));
            States.Add(("FL", "Florida"));
            States.Add(("GA", "Georgia"));
            States.Add(("HI", "Hawaii"));
            States.Add(("ID", "Idaho"));
            States.Add(("IL", "Illinois"));
            States.Add(("IN", "Indiana"));
            States.Add(("IA", "Iowa"));
            States.Add(("KS", "Kansas"));
            States.Add(("KY", "Kentucky"));
            States.Add(("LA", "Louisiana"));
            States.Add(("ME", "Maine"));
            States.Add(("MD", "Maryland"));
            States.Add(("MA", "Massachusetts"));
            States.Add(("MI", "Michigan"));
            States.Add(("MN", "Minnesota"));
            States.Add(("MS", "Mississippi"));
            States.Add(("MO", "Missouri"));
            States.Add(("MT", "Montana"));
            States.Add(("NE", "Nebraska"));
            States.Add(("NV", "Nevada"));
            States.Add(("NH", "New Hampshire"));
            States.Add(("NJ", "New Jersey"));
            States.Add(("NM", "New Mexico"));
            States.Add(("NY", "New York"));
            States.Add(("NC", "North Carolina"));
            States.Add(("ND", "North Dakota"));
            States.Add(("OH", "Ohio"));
            States.Add(("OK", "Oklahoma"));
            States.Add(("OR", "Oregon"));
            States.Add(("PA", "Pennsylvania"));
            States.Add(("RI", "Rhode Island"));
            States.Add(("SC", "South Carolina"));
            States.Add(("SD", "South Dakota"));
            States.Add(("TN", "Tennessee"));
            States.Add(("TX", "Texas"));
            States.Add(("UT", "Utah"));
            States.Add(("VT", "Vermont"));
            States.Add(("VA", "Virginia"));
            States.Add(("WA", "Washington"));
            States.Add(("WV", "West Virginia"));
            States.Add(("WI", "Wisconsin"));
            States.Add(("WY", "Wyoming"));
        }
        public static string[] Abbreviations()
        {
            List<string> abbrevList = new List<string>(States.Count);
            foreach (var state in States)
            {
                abbrevList.Add(state.Abbreviation);
            }
            return abbrevList.ToArray();
        }
        public static string[] Names()
        {
            List<string> nameList = new List<string>(States.Count);
            foreach (var state in States)
            {
                nameList.Add(state.Name);
            }
            return nameList.ToArray();
        }
    }
