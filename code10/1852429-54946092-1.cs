    public static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log)
    {
        //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        MemoryStream ms = new MemoryStream(); 
        await req.Body.CopyToAsync(ms);
        byte[] imageBytes = ms.ToArray();
        log.LogInformation(imageBytes.Length.ToString());
        // ignore below (not related)
        string finalString = "Upload succeeded";
        Returner returnerObj = new Returner();
        returnerObj.returnString = finalString;
        var jsonToReturn = JsonConvert.SerializeObject(returnerObj);
    
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
        };
    }
    
    public class Returner
    {
        public string returnString { get; set; }
    }
