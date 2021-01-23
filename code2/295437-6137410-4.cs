    public class Filter<T> where T: class
    {
        private readonly Predicate<T> criteria;
        public Filter(Predicate<T> criteria)
        {
            this.criteria = criteria;
        }
        public bool IsSatisfied(T obj)
        {
            return criteria(obj);
        }
    }
