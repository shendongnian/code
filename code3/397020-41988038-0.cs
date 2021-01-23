    public class MySerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (assemblyName.Contains("namespace I don't have") && typeName.Contains("type info I don't have"))
                    return typeof(MySubstitute);
            return Type.GetType($"{typeName}, {assemblyName}");
        }
    }
    
    [Serializable]
    public class MySubstitute
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
