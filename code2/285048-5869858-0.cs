    var client = new CookieAwareWebClient();
    client.Encoding = Encoding.UTF8;
    
    // Post values
    var values = new NameValueCollection();
    values.Add("username", someusername);
    values.Add("password", somepassword);
    values.Add("login", "Login");   //The button
    
    // Logging in
    client.UploadValues(loginPage, values); // You may verify the result
    
    // Download some secret page
    
    var html= client.DownloadString(someurl);
