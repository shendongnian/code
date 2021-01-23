    static void Main(string[] args)
    {
      Console.InputEncoding  = Encoding.GetEncoding(1252);
      Console.OutputEncoding = Encoding.GetEncoding(1252);
      System.Console.Out.WriteLine("œil"); 
                                          
      string euro = Console.In.ReadLine();
      Console.Out.WriteLine(euro);
    }
