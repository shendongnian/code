        public static IList<T?> Convert<T>(this IList<T> list) where T : struct
        {
            var newlist = new List<T?>(list.Count);
            for (int i = 0; i < list.Count; i++)
                newlist.Add(new T?(list[i]));
            return newlist;
        }
