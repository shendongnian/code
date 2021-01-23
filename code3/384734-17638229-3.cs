    public static class DynamicDictionaryExtensions
    {
        public static DynamicDictionary AsDynamicDictionary(this object data)
        {
            if (data == null) throw new ArgumentNullException("data");
            return new DynamicDictionary(
                   data.GetType().GetProperties()
                   .Where(p => p. && p.CanRead)
                   .Select(p => new {Name: p.Name, Value: p.GetValue(data, null)})
                   .ToDictionary(p => p.Name, p => p.Value)
            );
        }
    }
