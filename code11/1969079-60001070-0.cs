using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System.Collections.Generic;
// ...
public class MyClass {
  // ...
  /// <summary>
  /// List all Messages of the user's mailbox matching the query.
  /// </summary>
  /// <param name="service">Gmail API service instance.</param>
  /// <param name="userId">User's email address. The special value "me"
  /// can be used to indicate the authenticated user.</param>
  /// <param name="query">String used to filter Messages returned.</param>
  public static List<Message> ListMessages(GmailService service, String userId, String query)
  {
      List<Message> result = new List<Message>();
      UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
      request.Q = query; // inform this with the right query
      do
      {
          try
          {
              ListMessagesResponse response = request.Execute();
              result.AddRange(response.Messages);
              request.PageToken = response.NextPageToken;
          }
          catch (Exception e)
          {
              Console.WriteLine("An error occurred: " + e.Message);
          }
      } while (!String.IsNullOrEmpty(request.PageToken));
      return result;
  }
  // ...
}
So for your case you just need to add the line
C#
emailListRequest.Q = "has:attachment";
before executing the request, doing like this will not create a whole filter for your account, so maybe it's more convenient for your case. 
