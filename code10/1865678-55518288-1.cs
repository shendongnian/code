json
{
  "Email": "example@example.com",
  "CustomerNumber": 123456789,
  "ExternalMessageID": "1-222",
  "CustomerName": "John Smith",
  "CampaingName": "A Campaign name",
  "Extrafields": "opcional1;opcional2"
}
I'm assuming The "Extrafields" node is a string and not an array as it appears to have that kind of format.
To work with Json in C# you'll need to import [JSON.NET](https://www.newtonsoft.com/json) into your solution if you haven't already. We can then use your existing event handler on your code above and use it to create the following object:
c#
public class MailMessage
{
    public string Email { get; set; }
    public int CustomerNumber { get; set; }
    public string ExternalMessageID { get; set; }
    public string CustomerName { get; set; }
    public string CampaingName { get; set; }
    public string Extrafields { get; set; }
}
You can then use JSON.NET to serialize this object into a JSON string and POST that to your API in the format it is requiring. But being as your company also requires authentication, you will need to add a header to your POST request. I would also recommend using [RestSharp](https://www.nuget.org/packages/RestSharp) for this to make your life easier.
You can use something like the following to get all of this up and running:
c#
protected void Send_Button(object sender, EventArgs e)
{
    //Creates new MailMessage Object
    MailMessage mm = new MailMessage{
        Email = "someone@example.com",
        CustomerNumber = 123456789,
        ExternalMessageID = "1-222",
        CustomerName = "John Smith",
        CampaingName = "A Campaign name",
        Extrafields = "opcional1;opcional2"
    };
    var client = new RestClient("https://apitp.trial/"); //Makes a RestClient that will send your JSON to the server
    var request = new RestRequest("Online/Mail", Method.POST); //Sets up a Post Request your your desired API address
    request.AddHeader("api........?authorization", "INSERT YOUR BASE64 STRING HERE")
    request.AddHeader("Content-type", "application/json"); //Declares this request is JSOn formatted
    request.AddJsonBody(mm); //Serializes your MailMessage into a JSON string body in the request.
    var response = client.Execute(request); //Executes the Post Request and fills a response variable
}
Just insert your Base64 encrypted credentials where I have indicated and you can include some logic on the response variable to check it have processed properly. The Response variable has `StatusCode` on it, a code 200 will indicate a success.
