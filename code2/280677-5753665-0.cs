    static T ConvertTo<T>(XAttribute attr)
    {
        object value;
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Boolean: value = XmlConvert.ToBoolean(attr.Value); break;
            case TypeCode.Int32: value = XmlConvert.ToInt32(attr.Value); break;
            case TypeCode.DateTime: value = XmlConvert.ToDateTime(attr.Value); break;
            // Add support for additional TypeCode values here... 
            default:
                throw new ArgumentException(string.Format("Unsupported destination type '{0}'.", typeof(T)));
        }
        return (T)value;
    }
