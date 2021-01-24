    public static Option<IEnumerable<T>> AllSome<T>(this IEnumerable<Option<T>> input)
                where T : class
                => (input.All(o => o.IsSome)) ?
                    new Some<IEnumerable<T>>(input.Select(o => (o as Some<T>).Value)) :
                    new None<IEnumerable<T>>() as Option<IEnumerable<T>>;
