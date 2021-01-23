     public class JsonKnownTypeConverter : JsonConverter
    {
        public IEnumerable<Type> KnownTypes { get; set; }
        public JsonKnownTypeConverter() : this(ReflectTypes())
        {
            
        }
        public JsonKnownTypeConverter(IEnumerable<Type> knownTypes)
        {
            KnownTypes = knownTypes;
        }
        protected object Create(Type objectType, JObject jObject)
        {
            if (jObject["$type"] != null)
            {
                string typeName = jObject["$type"].ToString();
                return Activator.CreateInstance(KnownTypes.First(x => typeName == x.Name));
            }
            else
            {
                return Activator.CreateInstance(objectType);
            }
            throw new InvalidOperationException("No supported type");
        }
        public override bool CanConvert(Type objectType)
        {
            if (KnownTypes == null)
                return false;
            return (objectType.IsInterface || objectType.IsAbstract) && KnownTypes.Any(objectType.IsAssignableFrom);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            var target = Create(objectType, jObject);
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        //Static helpers
        static Assembly CallingAssembly = Assembly.GetCallingAssembly();
        static Type[] ReflectTypes()
        {
            List<Type> types = new List<Type>();
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var assemblyName in referencedAssemblies)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                Type[] typesInReferencedAssembly = GetTypes(assembly);
                types.AddRange(typesInReferencedAssembly);
            }
          
            return types.ToArray();
        }
        static Type[] GetTypes(Assembly assembly, bool publicOnly = true)
        {
            Type[] allTypes = assembly.GetTypes();
            List<Type> types = new List<Type>();
            foreach (Type type in allTypes)
            {
                if (type.IsEnum == false &&
                   type.IsInterface == false &&
                   type.IsGenericTypeDefinition == false)
                {
                    if (publicOnly == true && type.IsPublic == false)
                    {
                        if (type.IsNested == false)
                        {
                            continue;
                        }
                        if (type.IsNestedPrivate == true)
                        {
                            continue;
                        }
                    }
                    types.Add(type);
                }
            }
            return types.ToArray();
        }
