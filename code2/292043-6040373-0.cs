    class Program
    {
        static void Main(string[] args)
        {
            HttpWebResponse response = new HttpWebResponse();
            try
            {
                response.GetResponse();
            }
            catch (Exception ex)
            {
                //do something with the exception
            }
            finally
            {
                response.Dispose();
            }
        }
    }
