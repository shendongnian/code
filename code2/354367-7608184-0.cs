[ServiceContract(Namespace="Microsoft.WCF.Documentation")]
  public interface ISampleService{
    // This operation specifies an explicit protection level requirement.
    [OperationContract]
    string SampleMethod(string msg);
  }
  class SampleService : ISampleService
  {
  #region ISampleService Members
  public string  SampleMethod(string msg)
  {
    Console.WriteLine("Called with: {0}", msg);
 	  return "The service greets you: " + msg;
  }
  #endregion
  }
