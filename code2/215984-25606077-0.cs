    sealed class PreMergeToMergedDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return Type.GetType("BinarySerialization.YourClass");
        }
    }
    BinaryFormatter bfDeserialize = new BinaryFormatter();
    bfDeserialize.Binder = new PreMergeToMergedDeserializationBinder();
    while (fsRead.Position < fsRead.Length)
    {
        YourClass sibla = (YourClass)bfDeserialize.Deserialize(fsRead);
    }
