    var type = this.GetType();
    RuntimeTypeModel.Default.Add(type, true);
    Int32 i = 1;
    foreach(PropertyInfo info in type.GetProperties())
    {
        if(info.CanWrite)
        {
            RuntimeTypeModel.Default[type].AddField(i++, info.Name);
        }
    }
