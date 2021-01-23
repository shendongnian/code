    public static int Compare(string strA, string strB)
    {
        return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
    }
    public int CompareTo(string strB)
    {
        if (strB == null)
        {
            return 1;
        }
        return CultureInfo.CurrentCulture.CompareInfo.Compare(this, strB, CompareOptions.None);
    }
