    using System.Net;
    
    WebClient webClient = new WebClient();
    var forms = new NameValueCollection();
    forms["token"] = "abc123";
    var responseData = webClient.UploadValues(@"http://blabla.com/download/?name=abc.exe", "POST", forms);
    System.IO.File.WriteAllBytes(@"D:\abc.exe");
