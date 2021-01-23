    static int test = 0;
    static void Main(string[] args)
    {
      test = 1;
      Console.Write(test); // Should be 1
      resetTest();
      Console.Write(test); // Should be 0
    }
    
    static void resetTest()
    {
      test = 0;
    }
