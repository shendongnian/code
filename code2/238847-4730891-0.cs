       public class Parsers
        {
            private Parsers() { }
    
            public static void SetLong(ref long item, object value)
            {
                long temp;
                if (value != null && long.TryParse(value.ToString(), out temp)) { item = temp; }
            }
    
            public static void SetDateTime(ref DateTime item, object value)
            {
                DateTime temp;
                if (value != null && DateTime.TryParse(value.ToString(), out temp)) { item = temp; }
            }
    
            public static void SetInt(ref int item, object value)
            {
                int temp;
                if (value != null && int.TryParse(value.ToString(), out temp)) { item = temp; }
            }
    
            public static void SetString(ref string item, object value)
            {
                if (value != null) { item = value.ToString(); }
            }
        }
