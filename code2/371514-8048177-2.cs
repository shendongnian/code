    public enum OVType { OVLH, OVLL }
    public class LUOverVoltage
    {
        public string Name { get; set; }
        public OVType OVType { get; set; } 
    
        public List<string> PinGroups = new List<string>();
    
        public void Add(string name, OVType type, string Grp)
        {
            this.Name = name;
            this.OVType = type;
    
            PinGroups.Add(Grp);
        }
    }
