if (prop.PropertyType.IsEnum)
{
    return Enum.ToObject(prop.PropertyType, value);
}
else
{
    return Convert.ChangeType(value, prop.PropertyType);
}
