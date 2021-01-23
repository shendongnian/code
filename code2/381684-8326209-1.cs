	class Parser
	{
		public string PositionX { get; set; }
		public string PositionY { get; set; }
		public string PositionZ { get; set; }
		public Parser(XmlNode item)
		{
			this.PositionX = GetNodeValue(item, "Position/X");
			this.PositionY = GetNodeValue(item, "Position/X/Y");
			this.PositionZ = GetNodeValue(item, "Position/X/Y/Z");
		}
	}
