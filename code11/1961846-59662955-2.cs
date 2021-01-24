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
            if (lastElementProperty != null && (lastElementProperty is JArray) != isArray)
            {
                throw new ArgumentException($"Path part '{unsanitisedPathPart}' in '{path}' changed whether it was an array");
            }
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
}
string resultJson = result.ToString();
We keep the result as a `JObject`. For each path, we split it on `.` to get each of its parts, then walk through them, and at the same time walk down the object hierarchy from the outermost `JObject`, adding new elements to the object hierarchy as we go.
The tricky bit is determining when to add new elements to arrays. The logic is "if the array is empty, or the last element in the array already has the specified key". Note that it's not allowed to have arrays which directly contain arrays.
