    string savestring;
    public void Save()
    {
         savestring = mySerializableObject.SerializeXML<MySerializableClass>();
    }
    public void Load()
    {
         mySerializableObject  = savestring.DeserializeXML<MySerializableClass>();
    }
