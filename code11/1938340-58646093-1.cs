[HttpPost]
public void Post([FromBody] MyData myData)
{
    HttpContext.Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
    System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Request.Body);
    var requestBody = sr.ReadToEnd();
    //Now check the requestBody if the field was passed using JSON parsing or string manipulation
    Console.WriteLine(requestBody);
}
**Warning:** Though this will work. What you are trying do will reduce the readability and make it difficult for other developers. Differentiating if a field value is null or was not present in the request body is not a common practice.
