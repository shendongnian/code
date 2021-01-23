    public static void RemoveDuplicates(string[] array)
        {
            int c = 0;
            int i = -1;
            for (int n = 1; n < array.Length; n++)
            {
                if (array[c] == array[n])
                {
                    if (i == -1)
                    {
                        i = n;
                    }
                }
                else
                {
                    if (i == -1)
                    {
                        c++;
                    }
                    else
                    {
                        array[i] = array[n];
                        c++;
                        i++;
                    }
                }
            }
        }
