    public bool CheckForPairs(int[] array)
    {
        // Early out for odd arrays.
        // Using "& 1" is microscopically faster than "% 2" :)
        if ((array.Length & 1) == 1)
        {
            return false;
        }
        int[] counts = new int[32];
        int singleCounts = 0;
        foreach (int item in array)
        {
            int incrementedCount = ++counts[item];
            // TODO: Benchmark to see if a switch is actually the best approach here
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
