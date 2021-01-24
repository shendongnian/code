    static bool DoesExists(int[] a, int Value)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (Value == a[i])
                    {
                        return true;
                    }
                }
    
                return false;
            }
