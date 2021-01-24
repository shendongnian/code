json
{
    "Name": "John",
    "Surname": "Doe"
}
This is valid JSON which represents an object with two Properties `Name` and `Surname`, the C# representation would be this:
c#
public class Person
{
    public string Name {get; set;}
    public string Surname {get; set;}
}
Using Newtonsoft we can now deserialize our JSON to this Object like so:
c#
JsonConvert.DeserializeObject<Person>(json);
This is the simplest form of JSON deserializing, we have no nested objects and no lists/ arrays. Now lets look at those:
json
{
    "Name": "John",
    "Surname": "Doe",
    "Children": [{
            "Name": "Jane",
            "Surname": "Doe"
        },
        {
            "Name": "Jack",
            "Surname": "Doe"
        }
    ]
}
This now contains a JSON Array (`[ ... ]`) of Objects. We can see these Objects are once again just people. So we can alter our person class to this:
c#
public class Person
{
    public string Name {get; set;}
    public string Surname {get; set;}
    public List<Person> Children {get; set;}
}
Now lets get to your actual JSON. Looking at it this is the data structure I came up with:
c#
public class Parent
{
    [JsonProperty("modes")]
    public List<Mode> Modes {get; set;}
}
public class Mode
{
    public string Name {get; set;}
    public string ShortName {get; set;}
    public List<string> Channels {get; set;}
}
You can now deserialize the JSON like so:
c#
var deserialized = JsonConvert.DeserializeObject<Parent>(json);
I hope this helps you in future projects.
**Edit:** This won't fully work. I didn't see the `"modes": [` at the start of the JSON, this means there is a Parent object which I know nothing of. I fixed the deserializing
