	[TestFixture]
	public class TestClass
	{
		[Test]	
		public void MyTest()
		{
			var mocks = new MockRepository();
			var mockComponent = mocks.DynamicMock<MyComponent>();
			
			using (mocks.Record ())
			{
                Expect.Call(() => mockComponent.IsBusy())
                     .Do((Func<bool>)(() =>
                          {
                          		System.Threading.Thread.Sleep(10000); // wait 10 seconds
                          		return false;
                          }));
			}
			using (mocks.Playback())
			{
				var classUnderTest = new ClassUnderTest(mockComponent);
				classUnderTest.MethodUnderTest();
			}
			mocks.VerifyAll();
		}
	}
