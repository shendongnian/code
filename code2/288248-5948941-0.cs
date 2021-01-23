    public static int FindIndexOf(IEnumerable<Location> items,string val)
    {
        int index = -1;
        items.Where((x, i) => {
                    var ret = x.City == val;
                    if (ret)
                        index = i;
                    return ret;
                }).ToList();
        return index;
    }
