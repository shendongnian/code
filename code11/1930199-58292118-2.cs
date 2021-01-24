    public static MyStruct Total(this MyStruct[] source)
    {
        Debug.Assert(Marshal.SizeOf(typeof(MyStruct)) == 12);
        var span = new ReadOnlySpan<MyStruct>(source);
        var intSpan = MemoryMarshal.Cast<MyStruct, int>(span);
        var sum = new Vector<int>(0);
        for (int i = 0; i < span.Length - 1; i++)
        {
            var vector = new Vector<int>(intSpan.Slice(i * 3, 4));
            sum += vector;
        }
        // The last one must be added separately
        sum += new Vector<int>(new int[] {
            source[^1].PropA, source[^1].PropB, source[^1].PropC, 0 });
        return new MyStruct() { PropA = sum[0], PropB = sum[1], PropC = sum[2] };
    }
