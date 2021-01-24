csharp
client.DefaultRequestHeaders.Add("Acs-Api-Key","(key)");
Also something else that may cause issues is that you aren't wrapping your content in the "source" object like you are in PostMan. There are a couple ways of doing this
The first would be to simply wrap it in it's string format:
csharp
stringPayload = $"\"source\":{{{stringPayload}}}"
Or you can do it before you serialize by making your own object instead of having a Dictionary
var content = new PayloadObject(new Source("upload", "testdoc"));
var stringPayload = JsonConvert.SerializeObject(content);
// Send the request
class PayloadObject{
    Source source {get; set;}
    PayloadObject(Source source){
        this.source = source;
    }
}
class Source{
    string type {get; set;}
    string displayName {get; set;}
    Source(string type, string displayName){
        this.type = type;
        this.displayName = displayName;
    }
}
