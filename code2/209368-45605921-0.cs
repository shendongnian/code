    void Copy(object copyToObject, object copyFromObject)
    {
        BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
        FieldInfo[] fields = copyFromObject.GetType().GetFields(flags);
        for (int i = 0; i < fields.Length; ++i)
        {
            FieldInfo fromField = copyFromObject.GetType().GetField(fields[i].Name, flags);
            FieldInfo toField = copyToObject.GetType().GetField(fields[i].Name, flags);
            if(fromField != null)
            {
                toField.SetValue(copyToObject, fromField.GetValue(copyFromObject));
            }
        }
    }
