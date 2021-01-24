    var members = await graphClient
                  .Groups[$"{distributionListId}"]
                  .TransitiveMembers
                  .Request()
                  .GetAsync();
    //filter members by user type
    var users = members.OfType<Microsoft.Graph.User>();
    foreach (var user in users)
    {
       Console.WriteLine(user.Mail);
    }
