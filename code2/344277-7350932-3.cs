    public IEnumerable<ListItem> GetListItemsForEnum<EnumType>() where EnumType : struct
    {
        if (!typeof(EnumType).IsEnum) throw new InvalidOperationException("Generic type argument is not a System.Enum");
        var names = Enum.GetNames(typeof(EnumType));
        foreach (var name in names)
        {
            var item = new ListItem();
            var fieldInfo = typeof(EnumType).GetField(name);
            var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault(x => x is DescriptionAttribute) as DescriptionAttribute;
            if (attribute != null)
            {
                item.Text = attribute.Description;
                item.Value = Enum.Parse(typeof(EnumType), name).ToString();
                yield return item;
            }
        }
    }
