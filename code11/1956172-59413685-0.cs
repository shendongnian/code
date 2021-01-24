    public static IEnumerable<SelectListItem> GetGenericEnumSelectList<T>()
    {
        return (Enum.GetValues(typeof(T)).Cast<Enum>().Select(e => new SelectListItem() { Text = EnumExtensions.GetEnumDescription(e), Value = Convert.ToInt32(e).ToString() })).ToList();
    }
    public static string GetEnumDescription(Enum value)
    {
                FieldInfo fi = value.GetType().GetField(value.ToString());
    
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute),
                        false);
    
                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                
                    return value.ToString();
     }
