    static int[] cutTheSticks(int[] arr)
    {
        int n = arr.Length,
                k = 0;
        int[] result = new int[n];
        var arrToBeRemoved = arr.ToList();
        Array.Sort(arr);
        Array.Reverse(arr);
        while (arr.Length != 0)
        {
            if (k < n)
                result[k] = arr.Length;
            else
                break;
            if (k < arrToBeRemoved.Count)
                arrToBeRemoved.RemoveAt(k);
            arr = arrToBeRemoved.ToArray();
            k++;
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] -= arr[arr.Length - 1];
            }
         }
         return result;
    }
