c#
    void ParseCoordinateJSON()
    {
        var coordinates = new List<int[]>();
        var parsed = JObject.Parse(rawJson);
        var featureArray = parsed.SelectToken("features");
        var coordArray = featureArray.Children();
        coordArray.ToList().ForEach(n => ExtractCoordinates(n.SelectToken("coordinates"), coordinates));
        Debug.Log(string.Join("\n", coordinates.Select(c => $"({string.Join(", ", c)})")));
    }
    void ExtractCoordinates(JToken node, List<int[]> coordinates)
    {
        if (node == null)
        {
            return;
        }
        if (node.Children().Any(n => n.Type == JTokenType.Integer))
        {
            coordinates.Add(node.Children().Select(n => n.Value<int>()).ToArray());
            return;
        }
        node.Children().Where(n => n.Type == JTokenType.Array).ToList().ForEach(n => ExtractCoordinates(n, coordinates));
    }
Edit:
Here's it is without linq which might be easier to follow:
c#
void ParseCoordinateJSONNoLinq()
{
    var coordinates = new List<int[]>();
    var parsed = JObject.Parse(rawJSON);
    var featureArray = parsed.SelectToken("features");
        
    // These will be the objects with a "coordinates" key and an array value.
    var coordArray = featureArray.Children();
    foreach(var node in coordArray)
    {
        ExtractCoordinatesNoLinq(node.SelectToken("coordinates"), coordinates);
    }
    Console.WriteLine(string.Join("\n", coordinates.Select(c => $"({string.Join(", ", c)})")));
}
void ExtractCoordinatesNoLinq(JToken node, List<int[]> coordinates)
{
    var intValues = new List<int>();
    // Step through each child of this node and do something based on its node type.
    foreach(var child in node.Children())
    {
        // If the child is an array, call this method recursively.
        if (child.Type == JTokenType.Array)
        {
            // Changes to the coordinates list in the recursive call will persist.
            ExtractCoordinatesNoLinq(child, coordinates);
            
        // The child type is an integer, add it to the int values.
        } else if (child.Type == JTokenType.Integer)
        {
            intValues.Add(child.Value<int>());
        }
    }
    // Since we found int values at this level, add them to the shared coordinates list.
    if (intValues.Count > 0)
    {
        coordinates.Add(intValues.ToArray());
    }
}
If the rest of your data is reliable, I would use typical data objects and de-serialize to them then add something like the above as a [Custom JSON Converter](https://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm) for an object representing the jagged array.
c#
public class MyDataObject {
  public string SomeField {get; set;}
  public Vector2 Position {get; set;}
  [JsonProperty("features")]
  public JaggedFeatures {get; set;}
}
public class JaggedFeatures {
  public List<int[]> Coordinates {get; set;}
}
//...
JsonConvert.Deserialize<MyDataObject>(rawJSON, new JaggedFeaturesConverter())
