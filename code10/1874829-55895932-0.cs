     public IFoo GetFoo<T>(Func<IFoo, bool> predicate) where T : class
        {
            if (Foos != null && predicate != null)
            {
                var foos = Foos.Where(f => f is T);
                return foos.FirstOrDefault(predicate);
            }
            return null;
        }
