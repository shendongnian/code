    public void BruteStrings(int maxlength)
    {
       for(var i=1;i<i<=maxlength;i++)
          BruteStrings(Enumerable.Repeat((byte)0,i));
     
    }
    
    public void BruteStrings(byte[] bytes)
    {
       Console.WriteLine(bytes
                           .Cast<char>()
                           .Aggregate(new StringBuilder(), 
                              (sb,c) => sb.Append(c))
                           .ToString());
    
       if(bytes.All(b=>b.MaxValue)) return;
    
       bytes.Increment();
    
       BruteStrings(bytes);
    }
    
    public static void Increment(this byte[] bytes)
    {
       bytes.Last() += 1;
    
       if(bytes.Last == byte.MinValue)
       {
          var lastByte = bytes.Last()
          bytes = bytes.Take(bytes.Count() - 1).ToArray().Increment();
          bytes = bytes.Concat(new[]{lastByte});
       }
    }
