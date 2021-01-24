    [TestMethod]
    public void SomeClass_ShouldBehaveProperly_GivenSomeScenario() {
        var mock = new Mock<ISomeInterface>(); // Works for Strict or Loose
        mock.Setup(m => m.SomeMethod(It.IsAny<string>()))
            .Throws<InvalidOperationException>();
        mock.Setup(m => m.SomeMethod("aSpecificString"))
            .Returns(100);
        mock.Setup(m => m.SomeMethod("anotherString"))
            .Returns(1);
        Assert.AreEqual(100, mock.Object.SomeMethod("aSpecificString")); //PASS
        Assert.AreEqual(1, mock.Object.SomeMethod("anotherString")); //PASS
        Assert.ThrowsException<InvalidOperationException>(() => 
            mock.Object.SomeMethod("anyString")); //PASS
    }
