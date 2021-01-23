    [ThreadStatic] public static int i; // Declaration of the variable i with ThreadStatic Attribute.
    
    public static void Main()
    {
        new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                i++;
                Console.WriteLine("Thread A: {0}", i); // Uses one instance of the i variable.
            }
        }).Start();
    
        new Thread(() =>
       {
           for (int x = 0; x < 10; x++)
           {
               i++;
               Console.WriteLine("Thread B: {0}", i); // Uses another instance of the i variable.
           }
       }).Start();
    }
