    static class StateArray {
      static List<US_State> states;
      static StateArray() {
        states = new List<US_State>(50);
        states.Add(new US_State("AL", "Alabama"));
        states.Add(new US_State("AK", "Alaska"));
        states.Add(new US_State("AZ", "Arizona"));
        states.Add(new US_State("AR", "Arkansas"));
        states.Add(new US_State("CA", "California"));
        states.Add(new US_State("CO", "Colorado"));
        states.Add(new US_State("CT", "Connecticut"));
        states.Add(new US_State("DE", "Delaware"));
        states.Add(new US_State("DC", "District Of Columbia"));
        states.Add(new US_State("FL", "Florida"));
        states.Add(new US_State("GA", "Georgia"));
        states.Add(new US_State("HI", "Hawaii"));
        states.Add(new US_State("ID", "Idaho"));
        states.Add(new US_State("IL", "Illinois"));
        states.Add(new US_State("IN", "Indiana"));
        states.Add(new US_State("IA", "Iowa"));
        states.Add(new US_State("KS", "Kansas"));
        states.Add(new US_State("KY", "Kentucky"));
        states.Add(new US_State("LA", "Louisiana"));
        states.Add(new US_State("ME", "Maine"));
        states.Add(new US_State("MD", "Maryland"));
        states.Add(new US_State("MA", "Massachusetts"));
        states.Add(new US_State("MI", "Michigan"));
        states.Add(new US_State("MN", "Minnesota"));
        states.Add(new US_State("MS", "Mississippi"));
        states.Add(new US_State("MO", "Missouri"));
        states.Add(new US_State("MT", "Montana"));
        states.Add(new US_State("NE", "Nebraska"));
        states.Add(new US_State("NV", "Nevada"));
        states.Add(new US_State("NH", "New Hampshire"));
        states.Add(new US_State("NJ", "New Jersey"));
        states.Add(new US_State("NM", "New Mexico"));
        states.Add(new US_State("NY", "New York"));
        states.Add(new US_State("NC", "North Carolina"));
        states.Add(new US_State("ND", "North Dakota"));
        states.Add(new US_State("OH", "Ohio"));
        states.Add(new US_State("OK", "Oklahoma"));
        states.Add(new US_State("OR", "Oregon"));
        states.Add(new US_State("PA", "Pennsylvania"));
        states.Add(new US_State("RI", "Rhode Island"));
        states.Add(new US_State("SC", "South Carolina"));
        states.Add(new US_State("SD", "South Dakota"));
        states.Add(new US_State("TN", "Tennessee"));
        states.Add(new US_State("TX", "Texas"));
        states.Add(new US_State("UT", "Utah"));
        states.Add(new US_State("VT", "Vermont"));
        states.Add(new US_State("VA", "Virginia"));
        states.Add(new US_State("WA", "Washington"));
        states.Add(new US_State("WV", "West Virginia"));
        states.Add(new US_State("WI", "Wisconsin"));
        states.Add(new US_State("WY", "Wyoming"));
      }
      public static string[] Abbreviations() {
        List<string> abbrevList = new List<string>(states.Count);
        foreach (var state in states) {
          abbrevList.Add(state.Abbreviations);
        }
        return abbrevList.ToArray();
      }
      public static string[] Names() {
        List<string> nameList = new List<string>(states.Count);
        foreach (var state in states) {
          nameList.Add(state.Name);
        }
        return nameList.ToArray();
      }
      public static US_State[] States() {
        return states.ToArray();
      }
    }
    class US_State {
      public US_State() {
        Name = null;
        Abbreviations = null;
      }
      public US_State(string ab, string name) {
        Name = name;
        Abbreviations = ab;
      }
      public string Name { get; set; }
      public string Abbreviations { get; set; }
      public override string ToString() {
        return string.Format("{0} - {1}", Abbreviations, Name);
      }
    }
