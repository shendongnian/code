    static string[] GetPermutations(string input)
    {
        List<string> ret = new List<string>();
        List<string> cleanInput = new List<string>();
        foreach (string bit in input.Split('.'))
        {
            if (bit.Trim().Length > 0) cleanInput.Add(bit.Trim());
        }
        foreach (string bit in cleanInput)
        {
            if (ret.Count == 0)
            {
                ret.Add(bit);
                continue;
            }
            List<string> oldRet = ret;
            ret = new List<string>();
            foreach (string oldBit in oldRet)
            {
                ret.Add(oldBit + bit);
                ret.Add(oldBit + " " + bit);
            }
        }
        return ret.ToArray();
    }
