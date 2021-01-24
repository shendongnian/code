    public static int[] getRange(int[] T, int cible)
    {
        for (int i = 0; i < T.Length; ++i)
        {
            if (T[i] == cible)
            {
                int j = i + 1;
                while (j < T.Length && T[j] == cible) { ++j; }
                --j;
                if (i == j) { return new int[] { i }; }
                return new int[] { i, j };
            }
        }
        return new int[] { -1 };
    }
