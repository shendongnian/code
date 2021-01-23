    public static SelectList ToSelectList<T>(T selectedItem)
            {
                if (!typeof(T).IsEnum) throw new InvalidEnumArgumentException("The specified type is not an enum");
    
                var selectedItemName = Enum.GetName(typeof (T), selectedItem);
                var items = new List<SelectListItem>();
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    var fi = typeof(T).GetField(item.ToString());
                    var attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();
                    
                    var enumName = Enum.GetName(typeof (T), item);
                    var title = attribute == null ? enumName : ((DescriptionAttribute)attribute).Description;
                    
                    var listItem = new SelectListItem
                    {
                        Value = enumName,
                        Text = title,
                        Selected = selectedItemName == enumName
                    };
                    items.Add(listItem);
                }
    
                return new SelectList(items, "Value", "Text");
            }
