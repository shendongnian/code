       static bool testCaseThree(string str, out double ms)
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
                if (char.IsUpper(str[i]))
                {
                    result = true;
                    break;
                }
            }
            ms = (DateTime.Now - start).TotalMilliseconds;
            return result;
        }
