public class Trim
{
    public string model_id { get; set; }
    public string model_make_id { get; set; }
    public string model_name { get; set; }
    public string model_trim { get; set; }
    // .. lots of other properties
}
public class CarQueryApiTrimsResponse // This was RootObject - I renamed it.
{
    public List<Trim> Trims { get; set; }
}
It names the outermost class `RootObject` because it doesn't know what else to call it. I renamed it `CarQueryApiTrimsResponse` to indicate where it comes from. 
Include those classes in your project.
In your sample the variable with the response is called `carQueryTask`. To make it a little clearer I'll call it `carQueryResponseJson`. (I don't know how much better that is, but it says it's JSON.)
You'll need to trim those characters off the beginning and end, so you could create a function like this:
string TrimWeirdCharactersFromJson(string json)
{
    if (json.StartsWith("?("))
        json = json.Substring(2);
    if (json.EndsWith(");"))
        json = json.Substring(0, json.Length - 2);
    return json;
}
(I have to allow for the possibility that those characters are there for some reason of which I'm ignorant.)
Now, assuming you've added the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) package to your project, you can do this, starting with the JSON you've received:
// fix the weird characters
carQueryResponseJson = TrimWeirdCharactersFromJson(carQueryResponseJson);
// deserialize the JSON, creating an instance of CarQueryApiTrimsResponse
var trims = JsonConvert.DeserializeObject<CarQueryApiTrimsResponse>(carQueryResponseJson);
// Now you've got a strongly-typed object and you can access the contents of the 
// collection and properties of each trim.
foreach (var trim in trims.Trims)
{
    var modelName = trim.model_name;
     // do something with it
}
    
