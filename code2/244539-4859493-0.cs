        public static int[] FindLongestSequence(int[] seq)
        {
            int c_min = 0, c_len = 1;
            int min = 1, len = 0;
            for (int i = 0; i < seq.Length - 1; i++)
            {
                if(seq[i] < seq[i+1])
                {
                    c_len++;
                    if (c_len > len)
                    {
                        len = c_len;
                        min = c_min;
                    }
                } else
                {
                    c_min = i+1;
                    c_len = 1;
                }
            }
            return seq.Skip(min).Take(len).ToArray();
        }
    }
