C#
public static TAttributeType GetEnumValueAttribute<TAttributeType>(Enum val) 
    where TAttributeType : Attribute
{
    if (val == null)
    {
        return null;
    }
    var enumType = val.GetType();
    var memInfo = enumType.GetMember(val.ToString());
    var mem = memInfo.FirstOrDefault(m => m.DeclaringType == enumType);
    return mem.GetCustomAttributes<TAttributeType>().FirstOrDefault();
}
And in your loop:
C#
foreach (PropertyInfo pi in obj.GetType().GetProperties())
{
    // get the attribute from the property, if it exists
    AbbreviationAttribute attr = pi.GetCustomAttribute<AbbreviationAttribute>();
    if (attr != null)
    {
        //append the value from the attribute, instead of the property name
        values += $"{attr.Value}=";
        // if property is an enum (nullable or otherwise)
        if (pi.PropertyType.IsEnum || pi.PropertyType.IsNullableEnum())
        {
            values += $"{GetEnumValueAttribute<AbbreviationAttribute>((Enum)pi.GetValue(obj))?.Value};";
        }
        else
        {
            values += $"{pi.GetValue(obj)};";
        }
    }
}
You're really asking a duplicate of [this question](https://stackoverflow.com/a/1799401/424129). 
