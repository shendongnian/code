cs
var stringResult = await HttpCLient.GetStringAsync().Replace("**Result**", "Result");
Second create the classes which has the same properties as the json result.
cs
public class JsonResult
{
    public List<ResultObject> Result { get; set; }
    
    public int Id { get; set; }
    public string Exception { get; set; }
    public int Status { get; set; }
    public bool IsCanceled { get; set; }
    public bool IsComplete { get; set; }
    public int CreationOptions { get; set; }
    public string AsyncState { get; set; }
    public bool IsFaulted { get; set; }
}
public class ResultObject
{
    public int id { get; set; }
    public string name { get; set; }
    public string birthDate { get; set; }
    public string role { get; set; }
    public string originalList { get; set; }
}
And than deserialize the string with:
cs
var resultObject = JsonConvert.DeserializeObject<JsonResult>(result);
And `resultObject` will contain the whole result.
