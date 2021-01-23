    public class FieldAttribute : Attribute { }
    class Data
    {
        [Field]
        public int Num;
        [Field]
        public string Name;
        public decimal NonField;
    }
    
    class Deserializer
    {
        public static void Deserialize(object data)
        {
            var fields = data.GetType().GetFields();
            foreach (var field in fields)
            {
                Type t = field.FieldType;
                FieldAttribute attr = field.GetCustomAttributes(false)
                                         .Where(x => x is FieldAttribute)
                                         .FirstOrDefault() as FieldAttribute;
                if (attr == null) return;
                //now you have the type and the attribute
                //and even the field with its value
            }
        }
    }
----------
