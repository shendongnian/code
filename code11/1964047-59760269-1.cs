charp
private ObjectResult DeterminePositiveResponseType<T>(T response)
{
    Console.WriteLine(HttpMethod.Get.ToString());
    return HttpContext.Request.Method switch
    {
        string s when s == HttpMethod.Get.ToString() => Ok(response),
        string s when s == HttpMethod.Post.ToString() => Created("", response)
        _ => Ok(response), //this line to prevent throwing of SwitchExpressionException
    };
}
