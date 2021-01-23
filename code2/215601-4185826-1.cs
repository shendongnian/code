    public bool CheckForPairs(int[] array)
    {
        int[] counts = new int[32];
        int singleCounts = 0;
        foreach (int item in array)
        {
            int incrementedCount = ++counts[item];
            switch (incrementedCount)
            {
                case 1:
                    singleCounts++;
                    break;
                case 2:
                    singleCounts--;
                    break;
                case 3:
                    return false;
                default:
                    throw new InvalidOperationException("Shouldn't happen");
            }
        }
        return singleCounts == 0;
    }
