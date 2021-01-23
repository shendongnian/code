    [TestMethod]
    public void TestMethod()
    {
      System.CodeDom.CodeTypeReferenceCollection c = 
        new CodeDom.CodeTypeReferenceCollection();
      c.Add("Tuple<T,T,T,T,T>");
      //c[0].BaseType should be what's passed in,
      //but assertion will fail.
      Assert.AreEqual("Tuple<T,T,T,T,T>", c[0].BaseType);
    }
