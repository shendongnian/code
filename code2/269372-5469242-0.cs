    public virtual List<T> SelectRecord <T>(int items, IEnumerable<T> list)
        {
            if (items == -1)
                return list.ToList<T>();
            else
                if (items > list.Count<T>())
                    return list.ToList<T>();
                else
                    return list.Take<T>(items).ToList<T>();
        }
