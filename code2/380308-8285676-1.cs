    class Multiset<K> // maybe implement IEnumerable?
    {
        Dictionary<K, int> arities = new Dictionary<K, int>();
        ...
        Multiset<K> Except(Multiset<K> other)
        {
            foreach (var k in arities.keys)
            {
                int arity = arities[k];
                if (other.Contains(k))
                    arity -= other.Arity(k);
                if (arity > 0)
                    result.Add(k, arity);
            }
            return result;
        }
    }
