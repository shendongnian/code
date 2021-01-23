            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://www.majesticseo.com/account/login?EmailAddress=myemail&Password=mypass&RememberMe=1");
            
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:8.0) Gecko/20100101 Firefox/8.0";
            request.Referer = "https://www.majesticseo.com/account/login";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,**;q=0.8";
            request.UnsafeAuthenticatedConnectionSharing = true;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = true;
            // the post string for login form
            string postData = "redirect=&EmailAddress=EMAIL&Password=PASS";
            byte[] postBytes = System.Text.Encoding.ASCII.GetBytes(postData);
            request.ContentLength = postBytes.Length;
            System.IO.Stream str = request.GetRequestStream();
            str.Write(postBytes, 0, postBytes.Length);
            str.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream stream = response.GetResponseStream();
            string html = new System.IO.StreamReader(stream).ReadToEnd();
            Console.WriteLine("" + html);
