    [TestMethod]
    public void SomeClass_ShouldBehaveProperly_GivenSomeScenario2() {
        var mock = new Mock<ISomeInterface>();
        mock.Setup(m => m.SomeMethod(It.IsAny<string>()))
           .Throws<InvalidOperationException>();
        mock.Setup(m => m.SomeMethod("aSpecificString"))
            .Returns(100);
        mock.Setup(m => m.SomeMethod("aSpecificString"))
            .Returns(1);
        Assert.ThrowsException<InvalidOperationException>(() => 
            mock.Object.SomeMethod("anyString")); //PASS
        Assert.AreEqual(100, mock.Object.SomeMethod("aSpecificString")); //Fail
    }
