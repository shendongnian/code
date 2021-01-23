    class USState
    {
        public string Name;
        public string Abbrev;
    }
    string ListOfStates(List<USState> states)
    {
        return "States and their abbreviations:\n" + 
            string.Join("\n", 
                states.Select(s => s.Name)
                    .Zip(states.Select(s => s.Abbrev), (nm, ab) => nm + ": " + ab)
                    .ToArray()
                );
    }
