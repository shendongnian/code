    public IEnumerable<ListItem> GetListItemsForEnum<EnumType>()
       where EnumType: Enum
    {
         var names = Enum.GetNames(typeof(EnumType));
         foreach(var name in names)
         {
              ListItem item = new ListItem();
              var fieldInfo = typeof(EnumType).GetField(name);
              var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault(x is DescriptionAttribute) as DescriptionAttribute;
              if(attribute != null)
                 item.Text = attribute.Description;
 
              item.Value = Enum.Parse(name, typeof(EnumType)).ToString();
              yield return item;
         }
    }
