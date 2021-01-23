		public interface IX
		{
			void Execute(ref object param);
		}
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
			var tmp = inputValue;
			activity.Execute(ref tmp);
			activity
				.AssertWasCalled(x => x.Execute(
				  ref Arg<object>.Ref(Is.Same(outputValue), null).Dummy));
		}
