    string failureMessage = "failed";
    ValidateError(authDeserialized, "Succeed", "error", out failureMessage);
                                                      //^^^ This is what you have to change
    //Now you can assign failureMessage to any other value
    Model.Response= authResponse.Content;
    
    protected static void ValidateError(dynamic response, string validStatus,string categoryMatch, out string message)
    {                                                                                            //^^^ This is what you have to change
          if (response.result.status != validStatus)
          {
              try
              {
                   var category = response.result.category;
                   if (category == categoryMatch)
                       message=ErrorCodes.MessageFor(code,description);    //so i get the message back fine here but now how do i pass it back to this line   Model.Response= authResponse.Content; so that it can get saved?
              }
              catch (Exception) { }
              throw new Exception(message ?? "Request was not successfull");
          }
    }
