        public static class FlagExtensions
        {
            public static MyFlags Add(this MyFlags me, MyFlags toAdd)
	        {
		         return me | toAdd;
	        }
        }
        flags = flags.Add(MyFlags.Coke); // not gaining much here
