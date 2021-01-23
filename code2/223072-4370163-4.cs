	private Bar _bar;
	private IFoo _foo;
	[SetUp]
	public void BeforeEachTest()
	{
		var mocker = new RhinoAutoMocker<Bar>();
		_bar = mocker.ClassUnderTest;
		_foo = mocker.Get<IFoo>();
	}
	[Test]
	public void Given_input_length_equal_to_that_required_by_Like()
	{
		CallSave("".PadLeft(512));
	}
	[Test]
	public void Given_input_longer_than_required_by_Like()
	{
		CallSave("".PadLeft(513));
	}
	[Test]
	[ExpectedException(typeof(ExpectationViolationException))]
	public void Given_input_shorter_than_required_by_Like()
	{
		CallSave("".PadLeft(511));
	}
	private void CallSave(string value)
	{
		_bar.Save(value);
		_foo.AssertWasCalled(x => x.Write(Arg.Text.Like(".{512,}")));
	}
