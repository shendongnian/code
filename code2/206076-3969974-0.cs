    static void Main(string[] args)
    {
        var list = new List<Hierarchy1>();
        foreach (Hierarchy1Enum enum1 in Enum.GetValues(typeof(Hierarchy1Enum)))
        {
            var item1 = new Hierarchy1();
            list.Add(item1);
            item1.EnumValue = enum1;
            item1.NextList = new List<Hierarchy2>();
            foreach (Hierarchy2Enum enum2 in Enum.GetValues(typeof(Hierarchy2Enum)))
            {
                var item2 = new Hierarchy2();
                item1.NextList.Add(item2);
                item2.EnumValue = enum2;
                item2.NextList = new List<Hierarchy3>();
                foreach (Hierarchy3Enum enum3 in Enum.GetValues(typeof(Hierarchy3Enum)))
                {
                    var item3 = new Hierarchy3();
                    item2.NextList.Add(item3);
                    item3.EnumValue = enum3;
                    item3.Value = GetValue(enum1, enum2, enum3);
                }
            }
        }
    }
    private static decimal GetValue(Hierarchy1Enum enum1, Hierarchy2Enum enum2, Hierarchy3Enum enum3)
    {
        return // Calculate your value from enum1, enum2 and enum3
    }
