    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleCP(uint wCodePageID);
    static void Main(string[] args)
    {
      SetConsoleCP((uint)1252);
      Console.OutputEncoding = Encoding.UTF8;
      System.Console.Out.WriteLine("œil"); 
                                          
      string euro = Console.In.ReadLine();
      Console.Out.WriteLine(euro);
    }
