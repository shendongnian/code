    private bool ValidateCert(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
    	return true;
    }
    
    private string PostToSite(string url)
    {
    	string result = string.empty;
    
    	byte[] postBuffer = System.Text.Encoding.GetEncoding(1252).GetBytes("realm=vzw&goto=&gotoOnFail=&gx_charset=UTF-8&rememberUserNameCheckBoxExists=Y");
    
    	HttpWebRequest webRequest = (HttpWebRequest)Net.WebRequest.Create(_endpoint);
    	webRequest.KeepAlive = false;
    	webRequest.AllowAutoRedirect = false;
    
    	ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateCert);
    
    	webRequest.ContentLength = postBuffer.Length;
    	webRequest.Method = "POST";
    	webRequest.ContentType = "application/x-www-form-urlencoded";
    
    	using (Stream str = webRequest.GetRequestStream()) {
    		str.Write(postBuffer, 0, postBuffer.Length);
    	}
    
    	using (System.Net.HttpWebResponse res = (HttpWebResponse)webRequest.GetResponse()) {
    		using (StreamReader sr = new StreamReader(res.GetResponseStream())) {
    			result = sr.ReadToEnd();
    		}
    	}
    
    	return result;
    }
