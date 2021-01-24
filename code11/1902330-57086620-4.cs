`C#
    static class SerializerExtensions
    {
        public static T MergeObject<T>(this JsonSerializer serializer, JsonReader json, T target)
        {
            JObject o1 = JObject.FromObject(target, serializer);
            JObject o2 = serializer.Deserialize(json) as JObject;
            o1.Merge(o2, new JsonMergeSettings
            {   // union array values together to avoid duplicates
                MergeArrayHandling = MergeArrayHandling.Union,
				// an explicit null removes an existing item
				MergeNullValueHandling = MergeNullValueHandling.Merge,
            });
            serializer.Populate(o1.CreateReader(), target);
            return target;
        }
        public static T MergeObject<T>(this JsonSerializer serializer, JsonReader json, JObject template)
        {
            JObject o1 = template.DeepClone() as JObject;
            JObject o2 = serializer.Deserialize(json) as JObject;
            o1.Merge(o2, new JsonMergeSettings
            {   // union array values together to avoid duplicates
                MergeArrayHandling = MergeArrayHandling.Union,
				// an explicit null removes an existing item
				MergeNullValueHandling = MergeNullValueHandling.Merge,
            });
			
            return serializer.Deserialize<T>(o1.CreateReader());
        }
    }
`
  [1]: https://www.newtonsoft.com/json/help/html/MergeJson.htm
