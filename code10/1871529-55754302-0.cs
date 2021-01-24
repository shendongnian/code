	public class learnLine {
	
		static Char[] delimiters = { '[', ';', ')', '|', ' ' };
		
		public int num1 { get; set; }
		public int num2 { get; set; }
		public int num3 { get; set; }
		public int num4 { get; set; }
		public string letter { get; set; }	
		
		public learnLine (string line) {
			string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
			num1 = Convert.ToInt32(parts[0]);
			num2 = Convert.ToInt32(parts[1]);
			num3 = Convert.ToInt32(parts[2]);
			num4 = Convert.ToInt32(parts[3].Substring(0,1)); // from your logic it seems like you only want the first?
			letter = parts[4];
		}
		
		public override string ToString () =>
			$"contents: {num1}|{num2}|{num3}|{num4}|{letter}";
		
	}
