    public class LUOverVoltage
    {
        public string Name { get; set; }
        public OVType OVType { OVLH, OVLL }
    
        public List<string> PinGroups = new List<string>();
    
        public void Add(string name, OVType type, string Grp)
        {
            this.Name = name;
            this.OVType = type; //Why cannot reference a type through ab expression?
    
            PinGroups.Add(Grp);
        }
    }
