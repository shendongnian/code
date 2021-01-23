    public static void Execute<TKey>(this IDictionary<TKey, Action> actionMap, TKey key)
    {
        Action action;
        if (actionMap.TryGet(key, out action))
        {
             action();
        }
    }
