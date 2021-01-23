    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Throw()
        {
            int a = 0;
            int b = 10 / a;
        }
    }
