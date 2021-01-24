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
