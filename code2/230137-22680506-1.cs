    [Test]
    [RequiresSTA]
    public void test_something()
    {
      new KeyEventArgs(
        Keyboard.PrimaryDevice,
        new Mock<PresentationSource>().Object,
        0,
        Key.Back);
    }
