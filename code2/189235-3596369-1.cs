    static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
    private static byte[] GetBytes() {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            return box;
    }
    private static IList<T> InnerLoop(int n, IList<T> list) {
            var box = GetBytes(n);
            int k = (box[0] % n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
            return list;
    }
    
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            list = InnerLoop(n, list);
            n--;
        }
    }
