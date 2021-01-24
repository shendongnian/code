    public static class FindExtensions
    {
        public static T[] FindFirsts<T>(this IEnumerable<T> collection, 
            params Func<T, bool>[] conditions)
        {
            if (conditions.Length == 0)
                return new T[] { };
            var unmatchedConditions = conditions.Length;
            var lookupWork = conditions
                .Select(c => (
                    value: default(T),
                    found: false,
                    cond: c
                ))
                .ToArray();
            foreach (var item in collection) 
            {
                for (var i = 0; i < lookupWork.Length; i++)
                {
                    if (!lookupWork[i].found && lookupWork[i].cond(item))
                    { 
                        lookupWork[i].found = true;
                        lookupWork[i].value = item;
                        unmatchedConditions--;
                    }
                }
                if (unmatchedConditions <= 0)
                    break;
            }
            return lookupWork.Select(x => x.value).ToArray();
        }
    }
