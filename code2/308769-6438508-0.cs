    [TestMethod]
    public void test()
    {
      string s = "Mon Nov 16 19:15:09 +0600 2009";
      var result = DateTimeOffset.ParseExact(
        s, 
        "ddd MMM dd HH:mm:ss zzz yyyy", 
        System.Globalization.CultureInfo.InvariantCulture);
      Console.WriteLine(result);	
    }
