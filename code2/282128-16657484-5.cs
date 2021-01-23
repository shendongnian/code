    namespace DeSerialize
    {
    class Program
    {
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();
            string fromTypeName = "System.Collections.Generic.List`1[[Serialize.Result, Serialize, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]";
            string fromTypeName1 = "Serialize.Result";
            string toTypename = "System.Collections.Generic.List`1[DeSerialize.Result]";
            string toTypename1 = "DeSerialize.Result";
            string toTypeAssemblyName = Assembly.GetExecutingAssembly().FullName;
            DictionarySerializationBinder dic = new DictionarySerializationBinder();
            dic.AddBinding(fromTypeName, toTypename);
            dic.AddAssemblyQualifiedTypeBinding(fromTypeName1, toTypename1, toTypeAssemblyName);
            formatter.Binder = dic;
            Stream dStream = new FileStream(
                "SerializeList.bin",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            List<Result> listDS =
                (List<Result>)formatter.Deserialize(dStream);
            dStream.Close();
        }
    }
    sealed class DictionarySerializationBinder : SerializationBinder
    {
        Dictionary<string, Type> _typeDictionary = new Dictionary<string, Type>();
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToReturn;
            if (_typeDictionary.TryGetValue(typeName, out typeToReturn))
            {
                return typeToReturn;
            }
            else
            {
                return null;
            }
        }
        public void AddBinding(string fromTypeName, string toTypeName)
        {
            Type toType = Type.GetType(toTypeName);
            if (toType == null)
            {
                throw new ArgumentException(string.Format(
                "Help, I could not convert '{0}' to a valid type.", toTypeName));
            }
            _typeDictionary.Add(fromTypeName, toType);
        }
        public void AddAssemblyQualifiedTypeBinding(string fromTypeName, string toTypeName, string toTypeAssemblyName)
        {
            Type typeToSerializeTo = GetAssemblyQualifiedType(toTypeAssemblyName, toTypeName);
            if (typeToSerializeTo == null)
            {
                throw new ArgumentException(string.Format(
                "Help, I could not convert '{0}' to a valid type.", toTypeName));
            }
            _typeDictionary.Add(fromTypeName, typeToSerializeTo);
        }
        private static Type GetAssemblyQualifiedType(string assemblyName, string typeName)
        {
            return Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
        }
    }    
}
