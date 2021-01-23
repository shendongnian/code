    static bool CompareLongList(params int[] args)
        {
            if (args.Length > 1)
            {
                int value = args[0];
                for (int i = 1; i < args.Length; ++i)
                {
                    if (value != args[i])
                        return false;
                }
            }
            return true;
        }
