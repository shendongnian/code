    public enum MyEnum
    {
        AsciiName1,
        AsciiName2,
        AsciiName3,
    }
    public static class MyEnumExtensions
    {
        static readonly Dictionary<MyEnum, string> map = new Dictionary<MyEnum, string>
        {
            { MyEnum.AsciiName1, "NonAsciiName1" },
            { MyEnum.AsciiName2, "NonAsciiName2" },
            { MyEnum.AsciiName3, "NonAsciiName3" },
        };
        public static string GetValue(this MyEnum key)
        {
            return map[key];
        }
    }
