        string ToCustomId(MyEnum e) => e.ToString();
        string ToId(MyEnum e) => ListProducts.MyListOfProducts.First(x => x.CustomId == e.ToString()).Id;
        int ToEnumValue(MyEnum e) => (int)e;
        string ToEnumName(MyEnum e) => Enum.GetName(typeof(MyEnum), e);
        MyEnum FromCustomId(string customId) => (MyEnum)(int.Parse(customId));
        MyEnum FromId(string Id) => FromCustomId(ListProducts.MyListOfProducts.First(x => x.Id == Id).CustomId);
        MyEnum FromEnumValue(int enumValue) => (MyEnum)(enumValue);
        MyEnum FromEnumName(string name) => (MyEnum)Enum.Parse(typeof(MyEnum), name);
