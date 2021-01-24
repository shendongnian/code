    public void Delete<T>(T obj)
    {
        if (obj.GetType().Name == "Construction")
        {
            FieldInfo info = obj.GetType().GetField("Id");
            int id = (int)info.GetValue(obj);
        }
    }
