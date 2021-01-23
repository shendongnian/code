        public static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new Exception("first exception");
                }
                finally
                {
                    //try
                    {
                        throw new Exception("second exception");
                    }
                    //catch (Exception)
                    {
                        //throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
