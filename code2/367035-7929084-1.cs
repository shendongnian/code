    using System.Net.Http;
    
    var client = new HttpWebClient();
    
    // Get the response.
    HttpResponseMessage response = client.Get(
        // Note that you were incorrectly including the quotes, cURL
        // doesn't do that, it's needed on the command line to indicate
        // that it is a single argument.
        "http://api.repustate.com/v2/demokey/score.json?" + 
            "text=This%20is%20a%20block%20of%20text"));
    
    // Get the content.
    HttpContent content = response.Content;
    
    // Get the stream of the content.
    using (var reader = new StreamReader(content.ContentReadStream))
    {
        // Write the output.
        Console.WriteLine(reader.ReadToEnd());
    }
