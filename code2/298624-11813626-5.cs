        static bool testCaseFour(string str, out double ms)
        {
            bool result = false;
            DateTime start = DateTime.Now;
            if (string.IsNullOrEmpty(str))
            {
                ms = 0;
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > 64 && str[i] < 91)
                {
                    result = true;
                    break;
                }
            }
            ms = (DateTime.Now - start).TotalMilliseconds;
            return result;
        }
    }
