    public static void Into<TSource>(this IEnumerable<TSource> source,
        params Action<TSource>[] actions) 
    {
        if (ReferenceEquals(source, null)) {
            throw new ArgumentNullException("source");
        }
        if (ReferenceEquals(actions, null)) {
            throw new ArgumentNullException("actions");
        }
        foreach (var assignment in actions.Zip(source, (action, item) => new {
            Action = action,
            Item = item,
        })) {
            assignment.Action.Invoke(assignment.Item);
        }
    }
