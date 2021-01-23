    protected List<List<T>> AllCombos<T>(Func<List<T>, List<T>, bool> comparer, params T[] items)
        {
            List<List<T>> results = new List<List<T>>();
            List<T> workingWith = items.ToList();
            results.Add(workingWith);
            items.ToList().ForEach((x) =>
            {
                results.Add(new List<T>() { x });
            });
            for (int i = 0; i < workingWith.Count(); i++)
            {
                T removed = workingWith[i];
                workingWith.RemoveAt(i);
                List<List<T>> nextResults = AllCombos2(comparer, workingWith.ToArray());
                results.AddRange(nextResults);
                workingWith.Insert(i, removed);
            }
            results = results.Where(x => x.Count > 0).ToList();
            for (int i = 0; i < results.Count; i++)
            {
                List<T> list = results[i];
                if (results.Where(x => comparer(x, list)).Count() > 1)
                {
                    results.RemoveAt(i);
                }
            }
            return results;
        }
        protected List<List<T>> AllCombos2<T>(Func<List<T>, List<T>, bool> comparer, params T[] items)
        {
            List<List<T>> results = new List<List<T>>();
            List<T> workingWith = items.ToList();
            if (workingWith.Count > 1)
            {
                results.Add(workingWith);
            }
            for (int i = 0; i < workingWith.Count(); i++)
            {
                T removed = workingWith[i];
                workingWith.RemoveAt(i);
                List<List<T>> nextResults = AllCombos2(comparer, workingWith.ToArray());
                results.AddRange(nextResults);
                workingWith.Insert(i, removed);
            }
            results = results.Where(x => x.Count > 0).ToList();
            for (int i = 0; i < results.Count; i++)
            {
                List<T> list = results[i];
                if (results.Where(x => comparer(x, list)).Count() > 1)
                {
                    results.RemoveAt(i);
                }
            }
            return results;
        }
