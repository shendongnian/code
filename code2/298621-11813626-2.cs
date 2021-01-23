       static bool testCaseOne(string str, out double ms)
        {
            bool result = false;
            DateTime start = DateTime.Now;
            result = !string.IsNullOrEmpty(str) && str.Any(c => char.IsUpper(c));
            ms = (DateTime.Now - start).TotalMilliseconds;
            return result;
        }
