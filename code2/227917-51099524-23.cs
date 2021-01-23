    public static class MyExtensions
    {
        public static int Digits(this long n) =>
            // your favorite implementation goes here (one of the above provided)
			;
			
		public static int Digits_ConsideringMinusSign(this long n) =>
		    n < 0 ? 1 + Digits(n) : Digits(n);
    }
