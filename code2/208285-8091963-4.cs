    using System.Net;
    using System.Collections.Specialized;
    ...
    using (var wb = new WebClient())
    {
        var data = new NameValueCollection();
        data["username"] = "myUser";
        data["password"] = "myPassword";
    
        var response = wb.UploadValues(url, "POST", data);
        string responseInString = Encoding.UTF8.GetString(response);
    }
