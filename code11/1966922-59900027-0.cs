`
var filelists = [];
filelists.push({ Name: "Parker", Age: 27 });
$.ajax({
   url: '?handler=Test',
   contentType: 'application/json',
   data: JSON.stringify(filelists)
});
`
2 - in the server side 
`
// create a class called Test for deserializing the array
public class Test
{
  public string Name { get; set; }
  public int Age { get; set; }
}
// and add on get action without param
public JsonResult OnGetTest()
{
 // the first element is handler
  string data = HttpUtility.UrlDecode(HttpContext.Request.Query.Keys.ElementAt(1));
  IEnumerable<Test> deserializedData = JsonConvert.DeserializeObject<IEnumerable<Test>>(data);
  return new JsonResult("TEST");
}
`
