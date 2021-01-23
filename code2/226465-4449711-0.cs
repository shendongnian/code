    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception - {0}", e);
            }
        }
        static void Hop()
        {
            CheckStackTrace();
            Hip();
        }
        static void Hip()
        {
            CheckStackTrace();
            Hop();
        }
        static void CheckStackTrace()
        {
            StackTrace s = new StackTrace();
            if (s.FrameCount > 50)
                throw new Exception("Big stack!!!!");
        }
    }
