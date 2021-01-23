    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> target, int size)
    {
      var assigned = target.Select(
          (item, index) => new
          {
              Value = item,
              BatchNumber = index / size
          });
      foreach (var group in assigned.GroupBy(x => x.BatchNumber))
      {
          yield return group.Select(x => x.Value);
      }
    }
