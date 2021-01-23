    public static void Main(string[] args)
    {             
        string[] files = System.IO.Directory.GetFiles(@".", "*.*");      
        
        Parallel.ForEach(files, x =>
        {
          try
          {
            MyAction(x);
          }
          catch(Exception ex)
          {
            Console.WriteLine(ex.ToString());
          }
        });        
    }
    static void MyAction(string x)
    {      
      throw new ApplicationException("Testing: " + x);
    }
