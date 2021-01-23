    [TestMethod]
    public void MethodToTest_ScenarioToTest_ExpectedBehavior()
    {
        // Arrange
        var label = new MyLabel();
        var page = new TestPage()
        {
            IsPostBack = true
        };
        // Act
        label.MethodToTest(page);
        Assert.IsTrue(string.Empty, label.Text);
    }
