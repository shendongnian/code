    [TestMethod] // test passes
    public void TestLinqToObjects()
    {
      var stuff = new List<int?>() { null };
      var y = (from x in stuff
               select Convert.ToInt32(x))
               .First();
      Assert.AreEqual(0, y);
    }
