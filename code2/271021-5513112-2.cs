    HttpWebRequest myRequest =
     (HttpWebRequest)WebRequest.Create(URL);
                 myRequest.Method = "GET";
                 WebResponse myResponse = myRequest.GetResponse();
                 StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
     System.Text.Encoding.UTF8);
                 string result = sr.ReadToEnd();
                 //Console.WriteLine(result);
                 result = result.Replace('\n', ' ');
                 sr.Close();
                 myResponse.Close();
