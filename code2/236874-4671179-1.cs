    // 100 passes on a int[1000][1000] set size
    // 701% faster than original (14.26%)
    static int[][] CopyArrayLinq(int[][] source)
    {
        return source.Select(s => s.ToArray()).ToArray();
    }
    // 752% faster than original (13.38%)
    static int[][] CopyArrayBuiltIn(int[][] source)
    {
        var len = source.Length;
        var dest = new int[len][];
        for (var x = 0; x < len; x++)
        {
            var inner = source[x];
            var ilen = inner.Length;
            var newer = new int[ilen];
            Array.Copy(inner, newer, ilen);
            dest[x] = newer;
        }
        return dest;
    }
