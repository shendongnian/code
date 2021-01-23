    // Needs argument validation. Also, extending Dictionary<TKey, TValue>
    // probably isn't a great idea.
    public class ByTypeEvaluator : Dictionary<Type, Func<object, object>>
    {
        public void Add<T>(Func<T, object> selector)
        {
            Add(typeof(T), x => selector((T)x));
        }
      
        public object Evaluate(object key)
        {
            return this[key.GetType()](key);
        }
    }
