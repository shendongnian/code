	class Test {
		public bool? NullableBool { get; set;}
	}
	
	class MainClass
	{
		public static void Main ()
		{
			Test t1 = new Test { NullableBool = true };
			var a1 = new { NB = t1.NullableBool };
			
			Test t2 = new Test { NullableBool = null };
			var a2 = new { NB = t2.NullableBool };
		}
	}
