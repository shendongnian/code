    using System.Net.Http;
    
    var client = new HttpWebClient();
    
    // Create the HttpContent for the form to be posted.
    var requestContent = new FormUrlEncodedContent(new [] {
        new KeyValuePair<string, string>("text", "This is a block of text"),
    });
    // Get the response.
    HttpResponseMessage response = client.Post(
        "http://api.repustate.com/v2/demokey/score.json",
        requestContent);
    
    // Get the response content.
    HttpContent responseContent = response.Content;
    
    // Get the stream of the content.
    using (var reader = new StreamReader(responseContent.ContentReadStream))
    {
        // Write the output.
        Console.WriteLine(reader.ReadToEnd());
    }
