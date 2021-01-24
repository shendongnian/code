    public IEnumerable<T> GetRandomItem<T>(int count = 1, Rarity maxRarity = Rarity.Common, List<int> ids = null)
      where T : Item
    {
      InitializeActualRarities(maxRarity);
      Random rand = new Rand();
      return GetItems<T>().ToList().Where(i => CheckItemConditions(ref i, maxRarity, ids)).Clone().Select((x,i) => new {item = x, rand = rand.Next()}).OrderBy(x => x.rand).Select(x => x.item).Take(count);
    }
