    public static void Shuffle<T>(this Stack<T> source)
    {
        Random rng = new Random();
        T[] elements = source.ToArray();
        source.Clear();
        // Note i > 0 to avoid final pointless iteration
        for (int i = elements.Length - 1; i > 0; i--)
        {
            // Swap element "i" with a random earlier element it (or itself)
            int swapIndex = rng.Next(i + 1);
            T tmp = elements[i];
            elements[i] = elements[swapIndex];
            elements[swapIndex] = tmp;
        }
        foreach (T element in elements)
        {
            source.Push(element);
        }
    }
