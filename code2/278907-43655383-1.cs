    // Arrange
    widgetCreator
      .Setup(wc => wc.Create(It.IsAny<Widget>(), It.IsAny<AnotherParam>());
    
    // Act
    // Invoke action under test here...
    
    // Assert
    Func<Widget, bool> AssertWidget = request =>
    {
      Assert.AreEqual("Derived.Name", w.DerivedName);
      Assert.IsTrue(w.SomeOtherCondition);
      Assert.IsTrue(ap.AnotherCondition, "Oops");
      return true;
    };
    
    widgetCreator
      .Verify(wc => wc.Create(It.Is<Widget>(w => AssertWidget(w)), It.Is<AnotherParam>()), Times.Exactly(1));
