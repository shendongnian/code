    public static IEnumerable<T> TopologicalSort<T>(this IEnumerable<T> nodes, Func<T, IEnumerable<T>> connected)
    {
        var elems = nodes.ToDictionary(node => node, node => new HashSet<T>(connected(node)));
        while (elems.Count > 0)
        {
                var elem = elems.Where(x => x.Value.Count == 0).FirstOrDefault();
                if (elem.Key == null)
                {
                    throw new ArgumentException("Cyclic connections are not allowed");
                }
                elems.Remove(elem.Key);
                foreach (var selem in elems)
                {
                    selem.Value.Remove(elem.Key);
                }
                yield return elem.Key;
        }
    }
