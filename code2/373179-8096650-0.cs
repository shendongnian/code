    public override int GetHashCode()
    {
        int res = 0x2D2816FE;
        foreach(var item in this)
        {
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
    }
