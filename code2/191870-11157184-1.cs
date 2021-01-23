    /// <summary>
    /// return a random element of the list or default if list is empty
    /// </summary>
    /// <param name="e"></param>
    /// <param name="weightSelector">
    /// return chances to be picked for the element. A weigh of 0 or less means 0 chance to be picked.
    /// If all elements have weight of 0 or less they all have equal chances to be picked.
    /// </param>
    /// <returns></returns>
    public static T AnyOrDefault<T>(this IList<T> e, Func<T, double> weightSelector)
    {
        if (e.Count < 1)
            return default(T);
        if (e.Count == 1)
            return e[0];
        var weights = e.Select(o => Math.Max(weightSelector(o), 0)).ToArray();
        var sum = weights.Sum(d => d);
    
        var rnd = new Random().NextDouble();
        for (int i = 0; i < weights.Length; i++)
        {
            //Normalize weight
            var w = sum == 0
                ? 1 / (double)e.Count
                : weights[i] / sum;
            if (rnd < w)
                return e[i];
            rnd -= w;
        }
        throw new Exception("Should not happen");
    }
