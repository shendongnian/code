     WebRequest webRequest = WebRequest.Create("your url");
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                Console.WriteLine(response.StatusDescription);
                if (response.StatusDescription == "OK")
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    dynamic stuff = JObject.Parse(responseFromServer);
    
                    Console.Write(stuff.results);
                    //Iterate over images using a loop
    
                    //Condition to check if height and width are same Eg: responseFromServer.images.height == responseFromServer.images.width
    
                    // Store the url in a variable like String url = responseFromServer.images.url
    }
