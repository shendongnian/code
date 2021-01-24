    public static string GetWeird(string s1, string s2)
    {
       for (int i = 0; i < s1.Length; i++)
       {
          var ss1 = s1.Substring(i,s1.Length - i);
          var ss2 = s2.Substring(0, Math.Min(s2.Length , ss1.Length));
          Console.WriteLine($"{ss1}, {ss2}");
          if ( ss1 == ss2)
             return s1.Substring(0,i);
       }
       return s1;
    }
    
    public static void Main()
    {
       var s1 = "abcdhello";
       var s2 = "hellothere";
       var s3 = GetWeird(s1, s2);
       Console.WriteLine(s3);
    
    }
