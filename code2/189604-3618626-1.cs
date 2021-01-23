    foreach (FieldInfo field in fields)
    {
        size += averageTagSize;
        if (field.FieldType.Name == typeof(int).Name)
        {
            size += 32;
        }
        else if (field.FieldType.Name == typeof(string).Name)
        {
            string temp = field.GetValue(this) as string;
            size += temp.Length;
        }
    }
