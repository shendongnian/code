`csharp
using System;
using System.Collections.Generic;
public class HL7Node
{
	public IDictionary<string, object> Fields {get; set; }
	public List<HL7Node> Children { get; set; }
	
	public HL7Node() 
	{
		Children = new List<HL7Node>();
	}
}
`
Example usage (see also https://dotnetfiddle.net/EAh9iu):
`csharp
var root = new HL7Node {
  Fields = new Dictionary<string, object> {
    { "fname", "John" },
    { "lname", "Doe" },
    { "email", "jdoe@example.com" },
  },
};
var child = new HL7Node {
  Fields = new Dictionary<string, object> {
    { "fname", "Bob" },
    { "lname", "Doe" },
    { "email", "sdoe@example.com" },
  },
};
var grandChild = new HL7Node {
  Fields = new Dictionary<string, object> {
    { "fname", "Sally" },
    { "lname", "Doe" },
    { "email", "sdoe@example.com" },
  },
};
var greatGrandChild = new HL7Node {
  Fields = new Dictionary<string, object> {
    { "fname", "Ray" },
    { "lname", "Doe" },
    { "email", "sdoe@example.com" },
  },
};
root.Children.Add(child);
root.Children[0].Children.Add(grandChild);
root.Children[0].Children[0].Children.Add(greatGrandChild);
`
`csharp
var message = string.Format("Grandchild's name is {0}", root.Children[0].Children[0].Fields["fname"]);
`
I don't know what your naming conventions requirements are for HL7 message exchange, but perhaps there's some opportunity to still execute those with serialization *decorators* (i.e. [`Newtonsoft.Json.JsonPropertyAttribute`](https://www.newtonsoft.com/json/help/html/JsonPropertyName.htm)), anonymous objects, etc.
