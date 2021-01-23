    String username = "abc";
    String password = "123";
    String encoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + password));
    httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            
