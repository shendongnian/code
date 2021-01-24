    public static MyStruct Total(this List<MyStruct> source)
    {
        var sum = new MyStruct();
        var count = source.Count;
        for (int i = 0; i < count; i++)
        {
            var x = source[i];
            sum.PropA += x.PropA;
            sum.PropB += x.PropB;
            sum.PropC += x.PropC;
        }
        return sum;
    }
