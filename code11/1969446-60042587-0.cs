csharp
public static class Extensions
{
	public static T ToObject<T>(this string value)
	{
		//deserialize into a 'Node' first
		var node = JsonConvert.DeserializeObject<Node>(value);
		
		//then take the 'data' from that and 'ToObject' to the correct thing.
		return ((JObject) node.data).ToObject<T>();
	}
	
	private class Node{
		public object data {get;set;}
	}
}
The `ToObject<T>` method is what we'll use to convert our output to objects.
I've got the standard set of POCO for representing the data (albeit with bad naming conventions for the properties):
csharp
public class Movie {
	public string title {get;set;}
	public string tagline {get;set;}
}
public class Person {
	public string name {get;set;}
	public int born {get;set;}
}
public class RolesRel {
	public IEnumerable<string> roles {get;set;}
}
OK - now we're ready to go. I've changed the `Return` to look like this:
csharp
var shortestPath = graphClient.Cypher
	 .OptionalMatch("p = shortestPath((bacon: Person)-[*]-(meg: Person ) )")
	 .Where((Person bacon) => bacon.name == "Kevin Bacon")
	 .AndWhere((Person meg) => meg.name == "Meg Ryan")
	 .Return(p => new {
	 	Nodes = Return.As<IEnumerable<string>>("nodes(p)"),
		Relationships = Return.As<IEnumerable<RolesRel>>("rels(p)")
	 });
`string` is the only universal option we've got for deserializing multiple node types. In this scenario, as the relationships are all the same, we're all good on that front to just use a POCO - but if they weren't you'd end up doing what we're doing for Nodes for them as well.
Next, I run through the results:
csharp
foreach (var result in shortestPath.Results)
{
	foreach (var node in result.Nodes)
	{
		if(node.Contains("name"))
			Console.WriteLine(node.ToObject<Person>().name);
		else if(node.Contains("title"))
			Console.WriteLine(node.ToObject<Movie>().title);
		else {
			Console.WriteLine("Unknown Node Type: " + node);
		}
	}
}
I'm doing a naive check here for a property name I know is in one node type, but not another - and you may want to do it another way - but this works.
Obviously - I'm just outputting to the screen - but you will have access to the object itself.
