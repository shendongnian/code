    public Dictionary<int, decimal> CalculateBorderTotals(int monthNo, decimal totalConsumed, Dictionary<int, int> borderEnterRoom, Dictionary<int, int> borderLeftRoom)
    {
        var result = new Dictionary<int, decimal>();
        var minDay = borderEnterRoom.Values.Min();
        var maxDay = borderLeftRoom.Values.Max();
        var consumptionPerDay = totalConsumed / (maxDay - minDay);
        foreach (var item in borderEnterRoom)
        {
            if (borderLeftRoom.ContainsKey(item.Key))
                result.Add(item.Key, consumptionPerDay * (borderLeftRoom.FirstOrDefault(x => x.Key == item.Key).Value - item.Value) + 1); //The + 1 is discression depending how you calculate your number of days
            else
                result.Add(item.Key, consumptionPerDay * (DateTime.DaysInMonth(DateTime.Now.Year, monthNo) - item.Value + 1));
        }
        return result;
    }
