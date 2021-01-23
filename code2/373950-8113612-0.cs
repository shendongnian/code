    public static void MapAllFields(object source, object dst)
    {
        System.Reflection.FieldInfo[] ps = source.GetType().GetFields();
        foreach (var item in ps)
        {
            var o = item.GetValue(source);
            if (o != null)
            {
                var p = dst.GetType().GetField(item.Name);
                if (p != null)
                {
                    Type t = Nullable.GetUnderlyingType(p.FieldType) ?? p.FieldType;
                    object safeValue = (o == null) ? null : Convert.ChangeType(o, t);
                    p.SetValue(dst, safeValue);
                }
            }
        }
    }
