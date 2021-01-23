    //----------------------------------------------------------------------------------------------------
    /// <summary>A test for IsNetworkPath</summary>
    [TestMethod()]
    public void IsNetworkPathTest() {
      String s1 = @"\\Test"; // unc
      String s2 = @"C:\Program Files"; // local
      String s3 = @"S:\";  // mapped
      String s4 = "ljöasdf"; // invalid
      Assert.IsTrue(RPath.IsNetworkPath(s1));
      Assert.IsFalse(RPath.IsNetworkPath(s2));
      Assert.IsTrue(RPath.IsNetworkPath(s3));
      try {
        RPath.IsNetworkPath(s4);
        Assert.Fail();
      }
      catch {}
    }
