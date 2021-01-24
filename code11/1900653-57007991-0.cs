public static object GetDefaultValue(Type type)
{
    DefaultValueAttribute[] attributes = (DefaultValueAttribute[])type.GetCustomAttributes(typeof(DefaultValueAttribute), false);
    if (attributes != null && attributes.Length > 0)
    {
        return attributes[0].Value;
    }
    else
    {
        return null;
    }
}
And then you use it like this
 var val = EnumFunctions.GetDefaultValue(t);
 if(val != null)
     pi.SetValue(obj, val);
Source of your confusion: 
Generally speaking, generics are not runtime construct, they're compile-time construct, so you can't use them in reflection, because reflection works at run time. 
