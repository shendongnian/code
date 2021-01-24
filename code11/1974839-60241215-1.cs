    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Net;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                // Create a request for the URL.        
                WebRequest request = WebRequest.Create("https://api.binance.je/api/v3/time");
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                Console.WriteLine(response.StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
    
    
                //Create jsonObject object from the api call response
                JObject jObject = JObject.Parse(responseFromServer);
                //Read propertie called serverTime and convert this to string to match variabele set
                string time = jObject["serverTime"].ToString();
                //Write the given time
                Console.WriteLine(time);
    
    
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
    }
