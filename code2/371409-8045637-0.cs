    public override bool CanConvert(Type objectType)
    {
        FieldInfo[] fieldInfo = objectType.GetFields(BindingFlags.Public | BindingFlags.Static);
        if( fieldInfo.Length > 0 )
        {
            return ( fieldInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),false).Length > 0 );
        }
        else
        {
            return false;
        }
    }
