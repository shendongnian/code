    NameValueCollection postData = new NameValueCollection();
    postData.Add ("appid","001");
    postData.Add ("email","chris@test.com");
    postData.Add ("receipt","testing");
    postData.Add ("machineid","219481142226.1");
    
    WebClient wc = new WebClient();
    byte[] results = wc.UploadValues (
                           "http://www.example.com/licensing/check.php", 
                           postData);
    label2.Text = Encoding.ASCII.GetString(results); 
