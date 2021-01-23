    // Recursive
    public static List<List<T>> GetAllCombos<T>(List<T> list)
    {
      List<List<T>> result = new List<List<T>>();
      // head
      result.Add(new List<T>());
      result.Last().Add(list[0]);
      if (list.Count == 1)
        return result;
      // tail
      List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
      tailCombos.ForEach(combo =>
      {
        result.Add(new List<T>(combo));
        combo.Add(list[0]);
        result.Add(new List<T>(combo));
      });
      return result;
    }
    // Iterative, using 'i' as bitmask to choose each combo members
    public static List<List<T>> GetAllCombos<T>(List<T> list)
    {
      int comboCount = (int) Math.Pow(2, list.Count) - 1;
      List<List<T>> result = new List<List<T>>();
      for (int i = 1; i < comboCount + 1; i++)
      {
        // make each combo here
        result.Add(new List<T>());
        for (int j = 0; j < list.Count; j++)
        {
          if ((i >> j) % 2 != 0)
            result.Last().Add(list[j]);
        }
      }
      return result;
    }
    // Example usage
    List<List<int>> combos = GetAllCombos(new int[] { 1, 2, 3 }.ToList());
