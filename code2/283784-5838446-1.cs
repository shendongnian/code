    public enum MyEnum
    {
        value1 = 1,
        value2 = 2,
    }
    
    public static class EnumExtensions
    {
        public static string ToSwitch(this MyEnum val, string option)
        {
            switch (val)
            {
                case MyEnum.value1 : return "x " + option;
                case MyEnum.value2 : return "y " + option;
                default: return "error";
            }
        }
    }
