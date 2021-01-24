    System.Net.WebClient cli = new System.Net.WebClient();
    string authInfo = My.Settings.username + ":" + My.Settings.password;
    cli.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo)));
    cli.Headers.Add("Content-Type", "application/json");
    var bytes = Encoding.Default.GetBytes(jsonstringpayload);
    webClient.UploadDataAsync("http://support.example.com:8080/rest/" + url, "POST", bytes);
