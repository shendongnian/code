    public static class Storage
    {
        private static int a = 100;
		public static int A {
			get { return a; }
			set { a = value; b = a + 5; }
        }
        private static int b = a + 5;
		public static int B {
			get { return b; }
			set { b = value; }
		}
        public static int c;
    }
