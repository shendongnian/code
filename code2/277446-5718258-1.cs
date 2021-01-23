		[TestMethod]
		public void TestMethod()
		{
			// Variables needed - can be skipped
			var inputValue = new object();
			var outputValue = new object();
			IX activity = MockRepository.GenerateMock<IX>();
			// The stub:
			activity
				.Stub(x => x.Execute(
					ref Arg<object>.Ref(Is.Same(inputValue), outputValue).Dummy));
			activity.Execute(ref inputValue);
			activity
				.AssertWasCalled(x => x.Execute(
				  ref Arg<object>.Ref(Is.Same(inputValue), null).Dummy));
		}
