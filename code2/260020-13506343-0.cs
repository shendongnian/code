     static void Main(string[] args)
        {
           bool returnValue = false;
           new Thread(
              () =>
              {
                  returnValue =test() ; 
              }).Start();
            Console.WriteLine(returnValue);
            Console.ReadKey();
        }
        public static bool test()
        {
            return true;
        }
