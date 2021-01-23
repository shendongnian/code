    static void Main(string[] args)
            {
                object[] Objects = UserType.Login.GetStringValue();
                for (int x = 0; x < Objects.Length; ++x)
                    Console.WriteLine(Objects[x].ToString());
                Console.Read();
            }
        }
    
        public static class Extentions
        {
            public static object[] GetStringValue(this Enum value)
            {
                // Get the type
                Type type = value.GetType();
    
                // Get fieldinfo for this type
                FieldInfo fieldInfo = type.GetField(value.ToString());
    
                // Get the stringvalue attributes
                StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                    typeof(StringValueAttribute), false) as StringValueAttribute[];
    
                // Return the first if there was a match.
    
                object[] Vals = new object[3];
                Vals[0] = attribs[0].UserName;
                Vals[1] = attribs[0].PassWord;
                Vals[2] = attribs[0].Something;
                return Vals;
            }
        }
