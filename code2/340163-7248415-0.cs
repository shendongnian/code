    public Filter(SerializationInfo info, StreamingContext context)
    {
       Name = (String)info.GetValue("FilterName", typeof(String));
       Extensions = (String[])info.GetValue("FilterExtensions", typeof(String[]));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("FilterName", Name);
        info.AddValue("FilterExtensions", Extensions);
    }
