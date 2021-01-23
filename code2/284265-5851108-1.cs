    private static List<T> CreateFiveYearTemplate<T>(int startYear,
        int endYear, ObjectResult<T> result) where T: IYearTemplate, new()
    {
        var list = new List<T>(5);
        for (int year = startYear; year < endYear; ++year)
        {
            list.Add(new T() { Year = year, Cnt = 0 });
        }
        T tmpItem;
        foreach (var item in result)
        {
            tmpItem = list.Find(w => w.Year == item.Year);
            if (tmpItem == null)
            {
                tmpItem = new T() { Cnt = 0, Year = item.Year };
            }
            else
            {
                tmpItem.Cnt = item.Cnt;
            }
        }
        return list;
    }
