    /// <summary>
    /// Permutes the specified atoms; in lexicographical order.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="atoms">The atoms.</param>
    /// <param name="index">The index of the permutation to find.</param>
    /// <returns>The permutation.</returns>
    public static IList<T> Permute<T>(this IList<T> atoms, int index)
    {
        var result = new T[atoms.Count];
        Permute(atoms, result, index);
        return result;
    }
    /// <summary>
    /// Permutes the specified atoms; in lexicographical order.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="atoms">The atoms.</param>
    /// <param name="target">The array to place the permutation in.</param>
    /// <param name="index">The index of the permutation to find.</param>
    public static void Permute<T>(this IList<T> atoms, IList<T> target, int index)
    {
        if (atoms == null)
            throw new ArgumentNullException("atoms");
        if (target == null)
            throw new ArgumentNullException("target");
        if (target.Count < atoms.Count)
            throw new ArgumentOutOfRangeException("target");
        if (index < 0)
            throw new ArgumentOutOfRangeException("index");
        var order = atoms.Count;
        // Step #1 - Find factoradic of k
        var perm = new int[order];
        for (var j = 1; j <= order; j++)
        {
            perm[order - j] = index % j;
            index /= j;
        }
        // Step #2 - Convert factoradic[] to numeric permuatation in perm[]
        var temp = new int[order];
        for (var i = 0; i < order; i++)
        {
            temp[i] = perm[i] + 1;
            perm[i] = 0;
        }
        perm[order - 1] = 1;  // right-most value is set to 1.
        for (var i = order - 2; i >= 0; i--)
        {
            perm[i] = temp[i];
            for (var j = i + 1; j < order; j++)
            {
                if (perm[j] >= perm[i])
                    perm[j]++;
            }
        }
        // Step #3 - map numeric permutation to string permutation
        for (var i = 0; i < order; ++i)
        {
            target[i] = atoms[perm[i] - 1];
        }
    }
