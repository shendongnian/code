        private static string errorMessage;
        static void Main(string[] args)
        {
            try
            {
                Test1();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Something went wrong deep in the bowels of this application! " + errorMessage );
            }
        }
        static void Test1()
        {
            try
            {
                Test2(1);
                Test2(0);   
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw;
            }
        }
        static string Test2(int x)
        {
            if (x==0) throw new ArgumentException("X is 0!");
            return x.ToString();
        }
