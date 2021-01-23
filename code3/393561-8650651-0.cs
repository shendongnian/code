       public static CookieContainer login(string url, string username, string password, Form1 form)
       {
           if (url.Length == 0 || username.Length == 0 || password.Length == 0)
           {
               Console.WriteLine("Information missing");
               return null;
           }
           CookieContainer myContainer = new CookieContainer();
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
           request.CookieContainer = myContainer;
           // Set type to POST
           request.Method = "POST";
           request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
           request.ContentType = "application/x-www-form-urlencoded";
           // Build the new header, this isn't a multipart/form, so it's very simple
           StringBuilder data = new StringBuilder();
           data.Append("username=" + Uri.EscapeDataString(username));
           data.Append("&password=" + Uri.EscapeDataString(password));
           data.Append("&login=Login");
           // Create a byte array of the data we want to send
           byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
           // Set the content length in the request headers
           request.ContentLength = byteData.Length;
           Stream postStream;
           try
           {
               postStream = request.GetRequestStream();
           }
           catch (Exception e)
           {
               Console.WriteLine("Login - " + e.Message.ToString() + " (GRS)");
               return null;
           }
           // Write data
           postStream.Write(byteData, 0, byteData.Length);
           HttpWebResponse response;
           try
           {
               response = (HttpWebResponse)request.GetResponse();
           }
           catch (Exception e)
           {
               Console.WriteLine("Login - " + e.Message.ToString() + " (GR)");
               return null;
           }
           // Store the cookies
           if (myCollection.Any(c => c.Name.Contains("_u"))
           {
               string _url = "http://www.dandrews.net/forum/custom.php";
               string strResult = "";
               HttpWebRequest _request = (HttpWebRequest)HttpWebRequest.Create(_url);
               _request.CookieContainer = myContainer;
               HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
               using (StreamReader sr = new StreamReader(_response.GetResponseStream()))
               {
                   strResult = sr.ReadToEnd();
                   // Close and clean up the StreamReader
                   sr.Close();
               }
               form.userbox.Text = strResult;
               return myContainer;
           }
           else
           {
               return null;
           }
       }
