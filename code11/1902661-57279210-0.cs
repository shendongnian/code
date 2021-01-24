[HttpPost]
public IActionResult Post([FromForm] string body)
{
    var requestBody = body;
    var response = new MessagingResponse();
    if (string.Equals(requestBody,"hello",StringComparison.CurrentCultureIgnoreCase))
    {
        response.Message("Hi!");
    }
    else if (string.Equals(requestBody, "bye", StringComparison.CurrentCultureIgnoreCase))
    {
         response.Message("Goodbye");
    }
    // adding a default message in the event that the if/else if condition doesn't evaluate to true
   else
   {
         response.Message("Couldn't determine what to respond with");
   }
   return new ContentResult { Content = response.ToString(), ContentType = "application/xml", StatusCode = 200 };
}
Take a look and let me know what you think. 
