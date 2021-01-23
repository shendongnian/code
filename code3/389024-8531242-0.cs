    public void Sort(System.Collections.Generic.IComparer<T> comparer)
    {
        for (int i = 0; i < this.Count - 1; i++)
        {
            for (int j = i + 1; j < this.Count; j++)
            {
                if (comparer.Compare(this[i], this[j]) > 0)
                {
                    T tmp = this[i];
                    this[i] = this[j];
                    this[j] = tmp;
                }
            }
        }
    }
