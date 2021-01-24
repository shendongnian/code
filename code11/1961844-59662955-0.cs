var input = new List<(string path, string value)>
{
    ("books[].Categories[].Name", "Solo"),
    ("books[].Categories[].Type", "Drama"),
    ("books[].Categories[].Name", "Dougal and the blue cat"),
    ("books[].Categories[].Type", "Trippy"),
};
var result = new JObject();
foreach (var (path, value) in input)
{
    var pathParts = path.Split('.');
    JContainer parentNode = result;
    foreach (var unsanitisedPathPart in pathParts)
    {
        bool isArray = unsanitisedPathPart.EndsWith("[]");
        string pathPart = isArray
                    ? unsanitisedPathPart.Substring(0, unsanitisedPathPart.Length - "[]".Length)
                    : unsanitisedPathPart;
        JContainer currentNode = null;
        if (parentNode is JArray parentArray)
        {
            // Does the last element of the parent contain an object/value with this path?
            // If so, we need to add a new element
            var lastElementProperty = parentArray.Last?.Value<JToken>(pathPart);
            if (parentArray.Last == null || lastElementProperty is JObject || lastElementProperty is JValue)
            {
                currentNode = isArray ? (JContainer)new JArray() : new JObject();
                var newChild = new JObject()
                {
                    { pathPart, currentNode }
                };
                parentArray.Add(newChild);
            }
            else
            {
                parentNode = (JObject)parentArray.Last;
                // Fall through into the 'parentNode is JObject' case below
            }
        }
        if (parentNode is JObject parentObject)
        {
            // Does this element exist yet? If not, add it
            currentNode = parentObject.Value<JContainer>(pathPart);
            if (currentNode == null)
            {
                currentNode = isArray ? (JContainer)new JArray() : new JObject();
                parentObject.Add(pathPart, currentNode);
            }
        }
        Trace.Assert(currentNode != null);
        parentNode = currentNode;
    }
    if (parentNode is JObject finalObject)
    {
        ((JProperty)finalObject.Parent).Value = value;
    }
    else
    {
        throw new ArgumentException($"Final element must not be an array in '{path}'");
    }
    string resultJson = result.ToString();
