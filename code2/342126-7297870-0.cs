    public static void Recalculate<T>(IList<T> list,
                                      Func<T, bool> shouldCalculate,
                                      Func<T, T> calculation)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (shouldCalculate(items[i]))
            {
                items[i] = calculation(items[i]);
            }
        }
    }
