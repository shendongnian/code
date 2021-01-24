class Attribute
{
    public string Name { get; set; }
    public string Value { get ; set; }
}
(...)
var attributes = new List<Attribute>
{
    new Attribute() { Name="Color", Value="Blue" },
    new Attribute() { Name= "Weight", Value ="54.4kg" }
};
var d = attributes.ToDictionary(a=> a.Name, a => a.Value);
var json = System.Text.Json.JsonSerializer.Serialize(new { Attributes = d});
Console.WriteLine(json);
# Output
{"Attributes":{"Color":"Blue","Weight":"54.4kg"}}
----
In your case it could be something like the following.
Attributes = (from d in p.Attributes
                  orderby d.Name
                 select d).ToDictionary(a=> a.Name, a => a.Value)
