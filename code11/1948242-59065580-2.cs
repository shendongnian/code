    namespace ConsoleApp1
    {
      
        public int _secondThing // baaaad
        class Methods
        {
            public static int _thing; //good
            int _thing; //good, it's private;
            private int _thing; //good, it's the same
            public int _firstThing; //good
    
            static void Main(string[] args)
            {
                public int _first, _second, _third, _fourth, _fifth; //baaad
                int _first, _second; //good
            }
        }
    }
