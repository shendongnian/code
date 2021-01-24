`
var result = await HTTPRequest.PostAsyncResponse(URL, Params)
var token = JToken.Parse(result);
var data= token.Value<JArray>("data");
`
Or you can also use JsonPath:
`
var result = await HTTPRequest.PostAsyncResponse(URL, Params)
var token = JToken.Parse(result);
var data = token.SelectTokens("$.data[*]");
`
But really, you should be serilizing into an object and then using the properties to get the data (or other properties):
`
public class RootObject
{
    public bool post_parameters_error_flag { get; set; }
    public bool data_error_flag { get; set; }
    public int row_count { get; set; }
    public string message { get; set; }
    public List<string> title { get; set; }
    public List<string> data { get; set; }
}
var result = await HTTPRequest.PostAsyncResponse(URL, Params)
var item = JsonConvert.DeserializeObject<RootObject>(result);
var data = item.data;
`
