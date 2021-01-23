    public sealed class CurrentAssemblyDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            string name;
            if (assemblyName.Contains("ResizableControl"))
            {
                name = Assembly.GetAssembly(typeof(EntityLib.Pattern)).ToString();
            }
            else
            {
                name = assemblyName;
            }
            return Type.GetType(String.Format("{0}, {1}",
                typeName.Replace("ResizableControl", "EntityLib"), name));
        }
    }
