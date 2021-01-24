    using Newtonsoft.Json;  
    using Newtonsoft.Json.Linq;  
      
      
    namespace REST  
    {  
        class Program  
        {  
            static void Main(string[] args)  
            {  
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create("Site URL/_api/web/lists/getByTitle(List Name')/items");  
              
                endpointRequest.Method = "GET";  
                endpointRequest.Accept = "application/json;odata=verbose";  
                NetworkCredential cred = new System.Net.NetworkCredential("username", "password", "domain");  
                endpointRequest.Credentials = cred;  
                HttpWebResponse endpointResponse = (HttpWebResponse)endpointRequest.GetResponse();  
                try  
                {  
                    WebResponse webResponse = endpointRequest.GetResponse();  
                    Stream webStream = webResponse.GetResponseStream();  
                    StreamReader responseReader = new StreamReader(webStream);  
                    string response = responseReader.ReadToEnd();  
                    JObject jobj = JObject.Parse(response);  
                    JArray jarr = (JArray)jobj["d"]["results"];  
                    foreach (JObject j in jarr)  
                    {  
                        Console.WriteLine(j["Title"]+" "+j["Body"]);  
                    }  
                      
                    responseReader.Close();  
                    Console.ReadLine();  
                      
                      
                }  
                catch (Exception e)  
                {  
                    Console.Out.WriteLine(e.Message); Console.ReadLine();  
                }       
            }  
        }  
    } 
