    public class Class1<T>
        {
            private List<T> covariants = new List<T>();
    
            public List<T> mark(T item)
            {
                covariants.Add(item);
                return covariants;
            }
        }
