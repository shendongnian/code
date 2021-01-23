	public class LUOverVoltage
	{
		public enum OVType { OVLH, OVLL }
		public string Name { get; set; }
		public OVType ovType;
		public List<string> PinGroups = new List<string>();
		public void Add(string name, OVType type, string Grp)
		{
			this.Name = name;
			this.ovType = type;
			PinGroups.Add(Grp);
		}
	}
