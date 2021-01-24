    public class WeightedList<T> : IList<(T item, double weight)> 
    {
        // The method name Add is marked as source of error
        void ICollection<(T item, double weight)>.Add((T item, double weight) item)
        {
            this.Add(item.item, item.weight);
        }
    
        [...]
    }
