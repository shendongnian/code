    public static int MaxProduct(params int[] array)
    {
        int highest3 = int.MinValue; // Third highest.
        int highest2 = int.MinValue; // Second highest.
        int highest1 = int.MinValue; // Highest.
        int lowest2  = int.MaxValue; // Second lowest.
        int lowest1  = int.MaxValue; // Lowest.
        foreach (int n in array)
        {
            if (n > highest1)
            {
                highest3 = highest2;
                highest2 = highest1;
                highest1 = n;
            }
            else if (n > highest2)
            {
                highest3 = highest2;
                highest2 = n;
            }
            else if (n > highest3)
            {
                highest3 = n;
            }
            if (n < lowest1)
            {
                lowest2 = lowest1;
                lowest1 = n;
            }
            else if (n < lowest2)
            {
                lowest2 = n;
            }
        }
        // Answer is either the highest 3 or the lowest 2 and the highest 1
        // (because the product of two negatives is positive).
        int prodHighestOnly   = highest3 * highest2 * highest1;
        int prodHighestLowest = highest1 * lowest2  * lowest1;
        return Math.Max(prodHighestOnly, prodHighestLowest);
    }
