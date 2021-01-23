    public static string Post(string service, IDictionary<string, string> objects)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(ServiceAdress+service+".php");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
    
            StringBuilder b= new StringBuilder();
            foreach(KeyValuePair<string,string>  o in objects)
                b.Append(HttpUtility.UrlEncode(o.Key)).Append("=").Append(HttpUtility.UrlEncode(o.Value??"")).Append("&");
            if (PHPSESSID != null)
                b.Append("PHPSESSID=").Append(PHPSESSID).Append('&');
    
            string postData = b.ToString(0, b.Length - 1);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            
            if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                return null;
    
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
