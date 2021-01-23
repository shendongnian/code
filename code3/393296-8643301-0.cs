    static void ParamTest(System.Text.StringBuilder  paramSb)
    {
      paramSb.Append("World");
    }
    
    static void Main()
    {
      System.Text.StringBuilder sb = new StringBuilder();
      sb.Append("Hello");
            
      ParamTest(sb);
      Console.WriteLine(sb);
    }
