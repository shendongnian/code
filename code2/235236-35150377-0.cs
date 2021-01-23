    public static class UtilitiesClass
    {
        public static SelectList GetEnumType(Type enumType)
        {
            var value = from e in Enum.GetNames(enumType)
                        select new
                        {
                            ID = Convert.ToInt32(Enum.Parse(enumType, e, true)),
                            Name = e
                        };
            return new SelectList(value, "ID", "Name");
        }
    }
