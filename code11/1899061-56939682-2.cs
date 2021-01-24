    class List
    {
        double[] array = new double[18];
        int count = 0;
        internal int Count => count;
        internal bool Contains(double value)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
        internal void Clear()
        {
            count = 0;
        }
        internal void Add(double value)
        {
            array[count++] = value;
        }
    }
