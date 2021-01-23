	class LineGroup // name whatever the data contains
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public LineGroup(List<string> lines)
		{
			if (lines == null || lines.Count < 4)
			{
				throw new ApplicationException("LineGroup file format error: Each group must have at least 4 lines");
			}
			Name = lines[0];
			Code = lines[1];
			City = lines[lines.Count - 2];
			Country = lines[lines.Count - 1];
		}
	}
