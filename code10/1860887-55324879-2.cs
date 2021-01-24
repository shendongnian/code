    using Windows.Web.Http;
    var content = new HttpStringContent("grant_type=password&username=username&password=password");
    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    client.PostAsync(Url, content);
---
    var data = new Dictionary<string, string>
    {
        {"grant_type", "password"},
        {"username", "username"},
        {"password", "password"}
    };
    var content = new FormUrlEncodedContent(data);
    client.PostAsync(Url, content);
