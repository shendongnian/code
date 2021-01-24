    using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.10.89:8080/GameManage/userLogin/", json))
        {
           String username = "abc";
           String password = "123";
           String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
           www.SetRequestHeader("Authorization", "Basic " + encoded);
