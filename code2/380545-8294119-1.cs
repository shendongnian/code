    [Test]
    public void TestThatNameWasSet() {
        TestA systemUnderTest = new TestA();
        systemUnderTest.DoSomething("  new name  ");
        Assert.That(systemUnderTest.GetName(), Is.EqualTo("new name");
    }
