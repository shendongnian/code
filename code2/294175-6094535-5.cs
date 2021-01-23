    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                Console.ReadLine();
            }
    
            private static void First()
            {
                Second();
    
            }
    
            private static void Second()
            {
                Third();
    
            }
    
            private static void Third()
            {
                throw new SystemException("ERROR HERE!");
            }
        }
