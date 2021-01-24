    public IEnumerable<string> columnSortList
    {
        get
        {
            if (ColumnSort == null)
            {
                return Enumerable.Empty<string>();
            }
            else
            {
                return ColumnSort.Split(',')
                                 .Select(x => x.Trim())
                                 .Where(x => !string.IsNullOrWhiteSpace(x))
                                 .AsEnumerable();
            }
        }
    }
