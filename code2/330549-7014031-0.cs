	public class State
	{
		public int Id { get; set; }
		public int Switch1 { get; set; }
		public int Switch2 { get; set; }
		public int Switch3 { get; set; }
		public override bool Equals(object obj)
		{
			var other = obj as State;
			if (other != null)
			{
				return Switch1 == other.Switch1 &&
				       Switch2 == other.Switch2 &&
				       Switch3 == other.Switch3;
			}
			return false;
		}
	}
