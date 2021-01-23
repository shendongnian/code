        static bool testCaseTwo(string str, out double ms)
        {
            bool result = false;
            DateTime start = DateTime.Now;
            if (string.IsNullOrEmpty(str))
            {
                ms = 0;
                return false;
            }
            result = Regex.IsMatch(str, "[A-Z]");
            ms = (DateTime.Now - start).TotalMilliseconds;
            return result;
        }
