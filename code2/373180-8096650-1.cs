    public override int GetHashCode()
    {
        int res = 0x2D2816FE;
        int max = Math.Min(Count, 16);
        for(int i = 0, i != max; ++i)
        {
            var item = this[i];
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
    }
    public override int GetHashCode()
    {
        int res = 0x2D2816FE;
        int min = Math.Max(-1, Count - 16);
        for(int i = Count -1, i != min; --i)
        {
            var item = this[i];
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
    }
    public override int GetHashCode()
    {
        int res = 0x2D2816FE;
        int step = Count / 16 + 1;
        for(int i = 0, i < Count; i += step)
        {
            var item = this[i];
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
    }
