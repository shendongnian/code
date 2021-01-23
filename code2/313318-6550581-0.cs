    public static class Extensions
    {
        public static bool Equals(this FieldType field, DataType data)
        {
            return data.Equals(field);
        }
        public static bool Equals(this DataType data, FieldType field)
        {
            // Insert logic here
        }
    }
