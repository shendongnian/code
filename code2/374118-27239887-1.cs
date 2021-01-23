    string UniqueID(string CharList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        var t = DateTime.UtcNow;
        char[] charArray = CharList.ToCharArray();
        var result = new Stack<char>();
    
        var length = charArray.Length;
    
        long dgit = 1000000000000L +
                    t.Millisecond   * 1000000000L +
                    t.DayOfYear     * 1000000L +
                    t.Hour          * 10000L +
                    t.Minute        * 100L +
                    t.Second;
    
        while (dgit != 0)
        {
            result.Push(charArray[dgit % length]);
            dgit /= length;
        }
        return new string(result.ToArray());
    }
