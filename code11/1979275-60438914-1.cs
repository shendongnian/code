    public static void FisherYatesShuffle<T>(this IList<T> list, Random random)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int index = rnd.Next(0, list.Count - i);
            int lastIndex = list.Count - i - 1;
            T value = list[index];
            {
                T temp = list[num1];
                list[num1] = list[num2];
                list[num2] = temp;
            }
            list.RemoveAt(lastIndex);
            list.Add(value);
        }
    }
