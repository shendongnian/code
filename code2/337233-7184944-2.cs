    public static IEnumerable<T> PickRandom(int requested, IEnumerable<Stock<T>> list)
    {
        Random rng = new Random();
        for (int n = 0; n < requested; n++)
        {
            int cumulative = 0;
            var items = list.ToDictionary(item => 
                new { Start = cumulative, End = cumulative += item.Available });
            int choice = rng.Next(0, cumulative - 1);
            var foundItem = items.Single(i => 
                i.Key.Start <= choice && choice < i.Key.End).Value;
            foundItem.Available--;
            yield return foundItem.Item;
        }
    }
