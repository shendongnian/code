    [ServiceContract()] // Required: this is a WCF endpoint
    public interface IMyService
    {
         [OperationContract()] // Required so the method actually is included
         [WebGet(
              ResponseFormat = WebMessageFormat.Json, // Return results as JSON
              UriTemplate = "/categories/{language}/{category}")]
         CategoryResponse Find(string language, string category);
    }
