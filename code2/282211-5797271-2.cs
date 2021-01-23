        foreach(Fruit fruit in Concat<Fruit>(mApples, mBananas, mOranges))
        {
            fruit.Slice();
        }
        public static IEnumerable<T> Concat<T>(params IEnumerable<T>[] arr)
        {
        	foreach (IEnumerable col in arr)
        	foreach (T item in col)
        		yield return item;
        }
