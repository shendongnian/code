	public class MyFloat
	{
		float innerValue;
		// private constructor; instantiate using a float directly
		private MyFloat(float innerValue) { this.innerValue = innerValue; }
		public string Description { get { return "some metadata"; } }
		public int NumberOfFrames { get; set; }
		// conversion from MyFloat to float
		public static implicit operator float(MyFloat mine)
		{
			return mine.innerValue; // you can access private members here
		}
		// conversion from float to MyFloat
		public static implicit operator MyFloat(float val)
		{
			return new MyFloat(val); // use the private constructor
		}
	}
