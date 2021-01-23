        static List<int[]> getPermutationList(int length, int max)
        {
            List<int[]> perm_list = new List<int[]>();
            int[] perm = new int[length];
            for (int i = 0; i < length; ++i)
                perm[i] = 0;
            while(true)
            {
                for (int i = length - 1; ; --i)
                {
                    if (i == -1)
                        return perm_list;
                    if (perm[i] < max)
                    {
                        perm[i]++;
                        for (int j = i + 1; j < length; ++j)
                            perm[j] = 0;
                        break;
                    }
                }
                int[] perm_copy = new int[length];
                for (int i = 0; i < length; ++i)
                {
                    perm_copy[i] = perm[i];
                }
                perm_list.Add(perm_copy);
            }
            return perm_list;
        }
