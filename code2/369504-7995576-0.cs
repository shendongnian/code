    public static class MyExtensions
    {
        public static IEnumerable<List<SomeClass>> Split(this IEnumerable<SomeClass> source)
        {
            List<SomeClass> currentList = new List<SomeClass>();
            foreach (var item in source)
            {
                if(currentList.Count > 0 && item.State == States.NotOk)
                {
                    yield return currentList;
                    currentList = new List<SomeClass>();
                }
                currentList.Add(item);
            }
            if (currentList.Count > 0)
                yield return currentList;
        }
    }
