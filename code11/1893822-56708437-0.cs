    public class YearMonthDayTree<T>
        : Dictionary<int, Dictionary<int, Dictionary<int, List<T>>>>
    {
        public void Add(int year, int month, int day, T item)
        {
            if (!this.TryGetValue(year,
                out Dictionary<int, Dictionary<int, List<T>>> yearDict))
            {
                yearDict = new Dictionary<int, Dictionary<int, List<T>>>(12);
                this[year] = yearDict;
            }
            if (!yearDict.TryGetValue(month, out Dictionary<int, List<T>> monthDict))
            {
                monthDict = new Dictionary<int, List<T>>(31);
                yearDict[month] = monthDict;
            }
            if (!monthDict.TryGetValue(day, out List<T> dayList))
            {
                dayList = new List<T>();
                monthDict[day] = dayList;
            }
            dayList.Add(item);
        }
        public IEnumerable<(int Year, int Month, int Day, T Item)> Flatten()
        {
            foreach (var yearEntry in this)
            {
                int year = yearEntry.Key;
                foreach (var monthEntry in yearEntry.Value)
                {
                    int month = monthEntry.Key;
                    foreach (var dayEntry in monthEntry.Value)
                    {
                        int day = dayEntry.Key;
                        foreach (var item in dayEntry.Value)
                        {
                            yield return (year, month, day, item);
                        }
                    }
                }
            }
        }
    }
