    public static class Extensions
    {
        public static bool IsEquivalentTo(this FieldType field, DataType data)
        {
            return data.ToString() == field.ToString();
        }
    
        public static bool IsEquivalentTo(this DataType data, FieldType field)
        {
            return data.ToString() == field.ToString();
        }
    }
