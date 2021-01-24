`
{
    "status": 200,
    "result" {
        "postcode": "SW1A 1AA"
        "longitude":-0.141588
        "latitude":51.501009
    }
}
`
To make it valid json, it needs to look like this:
`
{
    "status": 200,
    "result": {
        "postcode": "SW1A 1AA",
        "longitude":-0.141588,
        "latitude":51.501009
    }
}
`
(and that's assuming that `result` is not an array. If it IS an array,  you will need [].)
There is a handy online tool I use all the time to make sure my json strings are valid: https://jsonformatter.curiousconcept.com/
Now that we have valid json to work with, we need a model to match it. Here's another handy online tool that converts your json string into c# objects: http://json2csharp.com/
Using that tool, we get this:
`
    public class RootObject
    {
        public int Status { get; set; }
        public Result Result { get; set; }
    }
    public class Result
    {
        public string Postcode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
`
And now, creating an instance of `RootObject` is as simple as:
    RootObject rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(rawJsonPostCodeString );
