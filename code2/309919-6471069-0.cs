	[Test]
	public void TestName()
	{
		  var b = MockRepository.GenerateStub<B>();
		  b.Stub(x => x.GetA())
			  .WhenCalled(x => x.ReturnValue = MockRepository.GenerateStub<A>());
		  Assert.IsFalse(ReferenceEquals(b.GetA(), b.GetA()));
	}
