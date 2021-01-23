    public static class EnumUtil<T>
    {
        public static Hashtable ToHashTable()
        {
            string[] names = Enum.GetNames(typeof(T));
            Array values = Enum.GetValues(typeof(T));
            Hashtable ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
                ht.Add(names[i], (int)values.GetValue(i));
            return ht;
        }
    }
