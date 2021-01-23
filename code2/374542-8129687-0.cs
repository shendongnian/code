    public static void WriteField(BinaryWriter bw, object obj, FieldInfo fieldInfo)
    {
        typeof(BinaryWriter)
            .GetMethod("Write", new Type[] { fieldInfo.FieldType })
            .Invoke(bw, new object[] { fieldInfo.GetValue(obj) });
    }
