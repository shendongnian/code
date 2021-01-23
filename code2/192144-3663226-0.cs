    internal virtual int IndexOf(T[] array, T value, int startIndex, int count)
    {
        int num = startIndex + count;
        for (int i = startIndex; i < num; i++)
        {
            if (this.Equals(array[i], value))
            {
                return i;
            }
        }
        return -1;
    }
