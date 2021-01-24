    public static int FirstDiffBinarySearch(string str1, string str2)
    {
        // "Fail fast" checks
        if (string.Equals(str1, str2, StringComparison.CurrentCultureIgnoreCase))
            return -1;
        if (str1 == null || str2 == null) return 0;
        int min = 0;
        int max = Math.Min(str1.Length, str2.Length);
        int mid = (min + max) / 2;
        while (min <= max)
        {               
            if (string.Equals(str1.Substring(0, mid), str2.Substring(0, mid), 
                StringComparison.CurrentCultureIgnoreCase))
            {
                min = mid + 1;                    
            }
            else
            {
                max = mid - 1;
            }
            mid = (min + max) / 2;
        }
        return mid;
    }
