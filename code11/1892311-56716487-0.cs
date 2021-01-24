    var currentUser = await GetUserByUserNameAsync(userId);
    var path = $"users/{currentUser.ObjectId}";
    var signinNames = new List<SignInName>();
    signinNames.Add(new SignInName
    {
         Type = "emailAddress",
         Value = newEmailaddress
    });
    var data = new B2CChangeEmailAddressData()
    {
         SignInNames = signinNames
    };
    var response = await _graphApi.SendAsync(new HttpMethod("PATCH"), path, null, data);
