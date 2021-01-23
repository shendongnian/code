    using System.ComponentModel;
    public enum MyEnum
    {
        [DescriptionAttribute("NonAsciiName1")] AsciiName1,
        [DescriptionAttribute("NonAsciiName2")] AsciiName2,
        [DescriptionAttribute("NonAsciiName3")] AsciiName3,
    }
    public static class MyEnumExtensions
    {
        public static string GetValue(this MyEnum key)
        {
            return typeof(MyEnum).GetField(key.ToString())
                                 .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                 .Cast<DescriptionAttribute>()
                                 .Single()
                                 .Description;
        }
    }
