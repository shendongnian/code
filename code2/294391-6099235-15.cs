    [TestMethod]
    public void TestMethod()
    {
      System.CodeDom.CodeTypeReferenceCollection c = 
        new CodeDom.CodeTypeReferenceCollection();
      c.Add("Tuple<T,T,T,T>");
      c.Add("Tuple<T,T,T,T,T>");
      //passes
      Assert.AreEqual("Tuple<T,T,T,T>", c[0].BaseType);
      //fails
      Assert.AreEqual("Tuple<T,T,T,T,T>", c[1].BaseType);    
    }
