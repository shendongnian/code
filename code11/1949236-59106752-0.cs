    /// <summary>
    /// Returns true if given char is found more than 1 time in string
    /// </summary>
    /// <param name="str">String to search into</param>
    /// <param name="c">Char to search for</param>
    /// <returns></returns>
    public static bool ExistsManyTimes(string str, char c)
    {
        return str.Count(x => x == c) > 1;
    }
