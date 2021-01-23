    public static void Main()
    {       
       using (TestTimer timer = new  TestTimer())
       {
           // do something
       }
       GC.Collect();
       GC.WaitForPendingFinalizers();
       Console.ReadKey();
    }
