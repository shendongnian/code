c#
// Assuming this is the type
Dictionary<Rarity, int> _actualRarityPercentages;
public IEnumerable<T> GetRandomItem<T>(int count = 1, Rarity maxRarity = Rarity.Common, List<int> ids = null)
  where T : Item
{
  InitializeActualRarities(maxRarity);
  int maxRarityValue = _actualRarityPercentages[maxRarity];
  return GetItems<T>().ToList()
        .Where(item => _actualRarityPercentages[item.Rarity] <= maxRarityValue)
        .Clone()
        .PickRandom(count)
}
I've assumed that `_actualRarityPercentages` is a straightforward dictionary from `Rarity` to `int`. Using [LINQ `Where`][1] you should be able to filter the items that are more rare than `maxRarity`.
Hope that helps
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=netframework-4.8
