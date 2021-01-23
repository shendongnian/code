    static int[] F(int[] A)
    {
        Dictionary<int, int> low = new Dictionary<int, int>();
        Dictionary<int, int> high = new Dictionary<int, int>();
        foreach (int a in A)
        {
            int lowLength, highLength;
            bool lowIn = low.TryGetValue(a + 1, out lowLength);
            bool highIn = high.TryGetValue(a - 1, out highLength);
            if (lowIn)
            {
                if (highIn)
                {
                    low.Remove(a + 1);
                    high.Remove(a - 1);
                    low[a - highLength] = high[a + lowLength] = lowLength + highLength + 1;
                }
                else
                {
                    low.Remove(a + 1);
                    low[a] = high[a + lowLength] = lowLength + 1;
                }
            }
            else
            {
                if (highIn)
                {
                    high.Remove(a - 1);
                    high[a] = low[a - highLength] = highLength + 1;
                }
                else
                {
                    high[a] = low[a] = 1;
                }
            }
        }
        int maxLow = 0, maxLength = 0;
        foreach (var pair in low)
        {
            if (pair.Value > maxLength)
            {
                maxLength = pair.Value;
                maxLow = pair.Key;
            }
        }
        int[] ret = new int[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            ret[i] = maxLow + i;
        }
        return ret;
    }
