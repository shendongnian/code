    [TestMethod]
    public void test()
    {
      string s = "Mon Nov 16 19:15:09 +0000 2009";
      var result = DateTimeOffset.ParseExact(
        s, 
        "ddd MMM dd HH:mm:ss zzz yyyy", 
        System.Globalization.CultureInfo.InvariantCulture);
      Assert.AreEqual(16, result.Day);
      Assert.AreEqual(11, result.Month);
      Assert.AreEqual(2009, result.Year);
      Assert.AreEqual(19, result.Hour);
      Assert.AreEqual(15, result.Minute);
      Assert.AreEqual(9, result.Second);
      Assert.AreEqual(0, result.Offset.Hours);    
    }
