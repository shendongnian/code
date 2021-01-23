    public void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
    {
        for (i = 0; i <= col.Count - 1; i++)
        {
            if (match(col(i)))
            {
                col(i) = newItem;
                break;
            }
        }
    }
