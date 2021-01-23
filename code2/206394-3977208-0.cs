    [TestFixture]
    public class SampleExceptionTest
    {
      [VerifyContract]
      public readonly IContract ExceptionTests = new ExceptionContract<SampleException>()
      {
        ImplementsSerialization = true,
      };
    }
