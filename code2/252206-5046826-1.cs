      [ServiceContract]
      public class AppCmdService
      {
        [WebGet(UriTemplate = "/GetCurrentExcutingRequests/?", ResponseFormat= WebMessageFormat.Json)]
        [OperationContract]
        public IEnumerable<ExecutingRequestJson> GetCurrentExcutingRequests()
        {      
          return CurrentExecutingRequestJsonProvider.GetCurrentExecutingRequests("localhost");
        }
      }
