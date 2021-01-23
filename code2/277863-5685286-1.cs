     public static class EnumEx
        {
            public static bool GetDescriptionAsBool(this Enum value)
            {
                FieldInfo field = value.GetType().GetField(value.ToString());
                DescriptionAttribute attribute
                        = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                            as DescriptionAttribute;
                if(attribute == null)
                {
                    //throw new SomethingWentWrongException();
                }
                return bool.Parse(attribute.Description);
            }
        }
