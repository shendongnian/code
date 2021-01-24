    [Test]
    public void CanSubstituteReadOnlyPropertyOnInterface()
    {
    
      var n = NSubstitute.Substitute.For<ITest>();
      n.X.Returns(55);
      Assert.AreEqual(55, n.X);
    
    }
    public interface ITest
    {
        int X { get; }
    
    }
