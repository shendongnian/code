    // Create a new WebClient instance to send the data with
    WebClient myWebClient = new WebClient();
    
    // Collection to hold our field data
    NameValueCollection postValues = new NameValueCollection();
    // Add necessary parameter/value pairs to the name/value container.
    postValues.Add("LoginName", tbLoginName.Text);
    postValues.Add("Password", tbPassword.Text);
    // Send off the message
    byte[] responseArray = myWebClient.UploadValues("http://website.com", postValues);
    // Decode and display the response.
    tbResponse.Text = Encoding.ASCII.GetString(responseArray);
