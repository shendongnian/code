    public static long CostOfMerge2(this IEnumerable<int> psrc)
    {
        long total = 0;
        var src = psrc.ToArray();
        Array.Sort(src);
        var i = 1;
        int length = src.Length;
        while (i < length)
        {
            var sum = src[i - 1] + src[i];
            total += sum;
            // find insert position for sum
            var index = Array.BinarySearch(src, i + 1, length - i - 1, sum);
            if (index < 0)
                index = ~index;
            --index;
            // shift items that come before insert position one place to the left
            if (i < index)
                Array.Copy(src, i + 1, src, i, index - i);
            src[index] = sum;
            ++i;
        }
        return total;
    }
