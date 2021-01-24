    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test { Bar = 1, Baz = 2, Foo = 3 };
    
            // Add JsonPropertyOrderConverter to enable ordering
            var opts = new JsonSerializerOptions();
            opts.Converters.Add(new JsonPropertyOrderConverter());
    
            var serialized = JsonSerializer.Serialize(test, opts);
    
            // Outputs: {"Bar":1,"Baz":2,"Foo":3}
            Console.WriteLine(serialized);
        }
    }
    
    class Test
    {
        [JsonPropertyOrder(1)]
        public int Foo { get; set; }
    
        [JsonPropertyOrder(-1)]
        public int Bar { get; set; }
    
        // Default order is 0
        public int Baz { get; set; }
    
    }
    
    /// <summary>
    /// Sets a custom serialization order for a property.
    /// The default value is 0.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class JsonPropertyOrderAttribute : Attribute
    {
        public int Order { get; }
    
        public JsonPropertyOrderAttribute(int order)
        {
            Order = order;
        }
    }
    
    /// <summary>
    /// For Serialization only.
    /// Emits properties in the specified order.
    /// </summary>
    class JsonPropertyOrderConverter : JsonConverter<object>
    {
        delegate ExpandoObject SorterFunc(object value, bool ignoreNullValues);
        private static readonly ConcurrentDictionary<Type, SorterFunc> _sorters
            = new ConcurrentDictionary<Type, SorterFunc>();
        public override bool CanConvert(Type typeToConvert)
        {
            // Converter will not run if there is no custom order applied
            var sorter = _sorters.GetOrAdd(typeToConvert, CreateSorter);
            return sorter != null;
        }
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            // Resolve the sorter.
            // It must exist here (see CanConvert).
            var sorter = _sorters.GetOrAdd(value.GetType(), CreateSorter);
            // Convert value to an ExpandoObject
            // with a certain property order
            var sortedValue = sorter(value, options.IgnoreNullValues);
            // Serialize the ExpandoObject
            JsonSerializer.Serialize(writer, (IDictionary<string, object>)sortedValue, options);
        }
        private SorterFunc CreateSorter(Type type)
        {
            // Get type properties ordered according to JsonPropertyOrder value
            var sortedProperties = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.GetCustomAttribute<JsonIgnoreAttribute>(true) == null)
                .Select(x => new
                {
                    Info = x,
                    Name = x.GetCustomAttribute<JsonPropertyNameAttribute>(true)?.Name ?? x.Name,
                    Order = x.GetCustomAttribute<JsonPropertyOrderAttribute>(true)?.Order ?? 0
                })
                .OrderBy(x => x.Order)
                .ToList();
            // If all properties have the same order,
            // there is no sense in explicit sorting
            if (!sortedProperties.Any(x => x.Order != 0))
            {
                return null;
            }
            // Return a function assigning property values
            // to an ExpandoObject in a specified order
            return new SorterFunc((src, ignoreNullValues) =>
            {
                IDictionary<string, object> dst = new ExpandoObject();
                foreach (var prop in sortedProperties)
                {
                    var propValue = prop.Info.GetValue(src);
                    if (!ignoreNullValues || !(propValue is null))
                    {
                        dst.Add(prop.Name, propValue);
                    }
                }
                return (ExpandoObject)dst;
            });
        }
    }
