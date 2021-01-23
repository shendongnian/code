            static void Main( string[] args )
            {
                var x = GetList ();
    
                if( _theList == null )
                {
                    Console.WriteLine ("_theList is null");
                }
                else
                {
                    Console.WriteLine ("_theList has been initialized.");
                }
                Console.ReadLine ();
            }
    
            private static List<int> _theList;
    
            public static List<int> GetList()
            {
                return _theList ?? ( _theList = new List<int> () );
            }
