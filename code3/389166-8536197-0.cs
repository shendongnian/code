    public void Method1()
    {
      foreach(int i in Enumerable.Range(0, 10))
      {
        int x = i * i;
        StringBuilder sb = new StringBuilder();
        sb.Append(x);
        Console.WriteLine(sb);
      }
    }
    public void Method2()
    {
      int x;
      StringBuilder sb;
      foreach(int i in Enumerable.Range(0, 10))
      {
        x = i * i;
        sb = new StringBuilder();
        sb.Append(x);
        Console.WriteLine(sb);
      }
    }
