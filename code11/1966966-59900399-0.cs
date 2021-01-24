    public static int IndexOfLastUniqueLetter(string original)
    {
        return original.IndexOf(
                        original.Distinct()
                                .Reverse()
                                .Where(x => original.Where(y => y.Equals(x)).Count() == 1)
                                .FirstOrDefault());
    }
