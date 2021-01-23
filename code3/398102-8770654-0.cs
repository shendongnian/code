    static void Main(string[] args)
            {
                IList test1 = GetList();
                IList test2= GetIList();
                ArrayList list1 = (ArrayList)test1; // Fails
                ArrayList list2 = (ArrayList)test2;  // Passes
    
                Console.ReadKey();
            }
    
            private static IList GetIList()
            {
                return new ArrayList();
            }
    
            private static IList GetList()
            {
                return new CustomList();
            }
