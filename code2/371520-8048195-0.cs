    public class LUOverVoltage
    {
        public string Name { get; set; }
        public OVType Type {get; set;}
      
        public enum OVType { OVLH, OVLL }
    
        public List<string> PinGroups = new List<string>();
    
        public void Add(string name, OVType type, string Grp)
        {
            this.Name = name;
            this.Type = type;
    
            PinGroups.Add(Grp);
        }
    }
