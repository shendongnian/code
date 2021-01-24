    public class JsonVisitor
    {
        private readonly HashSet<string> uniqueProperties;
        private readonly List<string> allProperties;
        public JsonVisitor()
        {
            uniqueProperties = new HashSet<string>();
            allProperties = new List<string>();
        }
        public string UniqueProperties => string.Join(Environment.NewLine, uniqueProperties);
        public string AllProperties => string.Join(Environment.NewLine, allProperties);
        public void Visit(JObject jObject)
        {
            uniqueProperties.Clear();
            allProperties.Clear();
            VisitObject(jObject, "");
        }
        private void VisitObject(JObject jObject, string currentPath)
        {
            foreach (var property in jObject.Properties())
            {
                uniqueProperties.Add(property.Name);
                var path = $"{currentPath}/{property.Name}";
                allProperties.Add(path);
                VisitToken(property.Value, path);
            }
        }
        private void VisitArray(JArray jArray, string currentPath)
        {
            for (var i = 0; i < jArray.Count; ++i)
            {
                var item = jArray[i];
                var path = $"{currentPath}[{i}]";
                VisitToken(item, path);
            }
        }
        private void VisitToken(JToken token, string currentPath)
        {
            if (token is JObject childObject)
                VisitObject(childObject, currentPath);
            else if (token is JArray childArray)
                VisitArray(childArray, currentPath);
        }
    }
