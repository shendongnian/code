    public static bool All(IEnumerable source, Predicate<object> criterion)
    {
        foreach (object item in source)
        {
            if (!criterion(item))
            {
                return false;
            }
        }
        return true;
    }
