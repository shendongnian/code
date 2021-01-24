    var headers = new Hashtable();
    var byteArray = Encoding.ASCII.GetBytes("username:password");
    headers.Add("Authorization", "Basic "+ Convert.ToBase64String(byteArray)); 
    using (UnityWebRequest www = 
    UnityWebRequest.Post("http://192.168.10.89:8080/GameManage/userLogin/", json, headers))
    {
     // your code
    }
