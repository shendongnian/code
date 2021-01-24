    public static bool CompareArrays(int[] array1, int[] array2)
    {
        // Create sets using Linq
        HashSet<int> set1 = array1.ToHashSet();
        HashSet<int> set2 = array2.ToHashSet();
        // Compare the sets with .SetEquals()
        return set1.SetEquals(set2);
    }
