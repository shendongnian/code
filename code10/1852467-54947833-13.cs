    public class MyEnumConverter
    {
        public static string ToCustomId(MyEnum e) => $"{(int)e}";
        public static string ToId(MyEnum e) => ListProducts.MyListOfProducts.First(x => x.CustomId == $"{(int)e}").Id;
        public static int ToEnumValue(MyEnum e) => (int)e;
        public static string ToEnumName(MyEnum e) => Enum.GetName(typeof(MyEnum), e);
        public static MyEnum FromCustomId(string customId) => (MyEnum)(int.Parse(customId));
        public static MyEnum FromId(string Id) => FromCustomId(ListProducts.MyListOfProducts.First(x => x.Id == Id).CustomId);
        public static MyEnum FromEnumValue(int enumValue) => (MyEnum)(enumValue);
        public static MyEnum FromEnumName(string name) => (MyEnum)Enum.Parse(typeof(MyEnum), name);
    }
