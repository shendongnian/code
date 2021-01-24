    [TestFixture]
    public class Dll_External_Tests
    {
        [Test]
        public void ShouldReturnAnInternalServiceFromCallingServiceFarAwayFromDLL()
        {
            // setup
           Helper helper = new Helper("a", "B");
           InternallService internalService = new InternallService(helper);
           DLL_external dLL_external = new DLL_external();
           // act
           var result = dLL_external.CallingServiceFarAwayFromDLL(internalService);
           // assert
           Assert.IsNotNull(result);
           Assert.IsTrue(result is InternallService);
           // add more assertions for what you expect the result to be
        }
    }
