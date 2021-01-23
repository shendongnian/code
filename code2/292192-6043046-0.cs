    public static void Main() 
        {
            string path = @"c:\MyDir\temp";
            try 
            {
                Directory.Delete(path, true);
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            } 
            finally {}
        }
