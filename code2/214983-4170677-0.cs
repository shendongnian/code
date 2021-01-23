    using System;  
    using System.IO;  
    using System.Net;  
    using System.Text;  
      
    // Create the web request  
    HttpWebRequest request = WebRequest.Create("http://www.someapi.com/") as HttpWebRequest;  
      
    // Get response  
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)  
    {  
        // Get the response stream  
        StreamReader reader = new StreamReader(response.GetResponseStream());  
      
        // Console application output  
        Console.WriteLine(reader.ReadToEnd());  
    }
