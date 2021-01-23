    public class ErrorResponse
    {
      public string error { get; set; }
    }
    [WebMethod]
    public static ErrorResposne Login(string username, string password)
    { 
      var response = new ErrorResponse();
      response.error = "No IDs";
      return response;
    }
