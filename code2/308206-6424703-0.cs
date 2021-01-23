    public int? ParseAnInt(string s)
    {
      var match = System.Text.RegularExpressions.Regex.Match(s, @"\d+");
      if (match.Success)
      {
        int result;
        //still use TryParse to handle integer overflow
        if (int.TryParse(match.Value, out result))
          return result;
      }
      return null;
    }
    [TestMethod]
    public void TestThis()
    {
      Assert.AreEqual(15, ParseAnInt("15 person"));
      Assert.AreEqual(15, ParseAnInt("person 15"));
      Assert.AreEqual(15, ParseAnInt("person15"));
      Assert.AreEqual(15, ParseAnInt("15person"));
      Assert.IsNull(ParseAnInt("nonumber"));
    }
