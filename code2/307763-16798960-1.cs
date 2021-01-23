    ComboBox.DataSource = EnumList.Of<DomainTypes>();
    ...
    public class EnumList
    {
        public static List<T> Of<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(x => 
                    {
                        BrowsableAttribute attribute = typeof(T)
                            .GetField(Enum.GetName(typeof(T), x))
                            .GetCustomAttributes(typeof(BrowsableAttribute),false)
                            .FirstOrDefault() as BrowsableAttribute;
                        return attribute == null || attribute.Browsable == true;
                    }
                )
            .ToList();
        }
    }
