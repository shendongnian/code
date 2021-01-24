    public interface ITakeAndSkip<out T> : IEnumerable<T>
    {
        ITakeAndSkip<T> ThenSkip(int number);
        ITakeAndSkip<T> ThenTake(int number);
        ITakeAndSkip<T> ThenTakeWhile(Func<T, bool> predicate);
        ITakeAndSkip<T> ThenSkipWhile(Func<T, bool> predicate);
    }
    public class TakeAndSkip<T> : ITakeAndSkip<T>
    {
        private readonly IEnumerable<T> _source;
        private class TakeOrSkipOperation
        {
            public bool IsSkip { get; private set; }
            public Func<T, bool> Predicate { get; private set; }
            public int Number { get; private set; }
            private TakeOrSkipOperation()
            {
            }
            public static TakeOrSkipOperation Skip(int number)
            {
                return new TakeOrSkipOperation
                {
                    IsSkip = true,
                    Number = number
                };
            }
            public static TakeOrSkipOperation Take(int number)
            {
                return new TakeOrSkipOperation
                {
                    Number = number
                };
            }
            
            public static TakeOrSkipOperation SkipWhile(Func<T, bool> predicate)
            {
                return new TakeOrSkipOperation
                {
                    IsSkip = true,
                    Predicate = predicate
                };
            }
            public static TakeOrSkipOperation TakeWhile(Func<T, bool> predicate)
            {
                return new TakeOrSkipOperation
                {
                    Predicate = predicate
                };
            }
        }
        private readonly List<TakeOrSkipOperation> _operations = new List<TakeOrSkipOperation>();
        public TakeAndSkip(IEnumerable<T> source)
        {
            _source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            using (var enumerator = _source.GetEnumerator())
            {
                // move to the first item and if there are none just return
                if (!enumerator.MoveNext()) yield break;
                // Then apply all the skip and take operations
                foreach (var operation in _operations)
                {
                    int n = operation.Number;
                    // If we are not dealing with a while then make the predicate count
                    // down the number to zero.
                    var predicate = operation.Predicate ?? (x => n-- > 0);
                    // Iterate the items until there are no more or the predicate is false
                    bool more = true;
                    while (more && predicate(enumerator.Current))
                    {
                        // If this is a Take then yield the current item.
                        if (!operation.IsSkip) yield return enumerator.Current;
                        more = enumerator.MoveNext();
                    }
                    
                    // If there are no more items return
                    if (!more) yield break;
                }
                // Now we need to decide what to do with the rest of the items. 
                // If there are no operations or the last one was a skip then
                // return the remaining items
                if (_operations.Count == 0 || _operations.Last().IsSkip)
                {
                    do
                    {
                        yield return enumerator.Current;
                    } while (enumerator.MoveNext());
                }
                // Otherwise the last operation was a take and we're done.
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public ITakeAndSkip<T> ThenSkip(int number)
        {
            _operations.Add(TakeOrSkipOperation.Skip(number));
            return this;
        }
        public ITakeAndSkip<T> ThenSkipWhile(Func<T, bool> predicate)
        {
            _operations.Add(TakeOrSkipOperation.SkipWhile(predicate));
            return this;
        }
        public ITakeAndSkip<T> ThenTake(int number)
        {
            _operations.Add(TakeOrSkipOperation.Take(number));
            return this;
        }
        public ITakeAndSkip<T> ThenTakeWhile(Func<T, bool> predicate)
        {
            _operations.Add(TakeOrSkipOperation.TakeWhile(predicate));
            return this;
        }
    }
 
    public static class TakeAndSkipExtensions
    {
        public static ITakeAndSkip<T> FirstTake<T>(this IEnumerable<T> source, int number)
        {
            return new TakeAndSkip<T>(source).ThenTake(number);
        }
        
        public static ITakeAndSkip<T> FirstSkip<T>(this IEnumerable<T> source, int number)
        {
            return new TakeAndSkip<T>(source).ThenSkip(number);
        }
        public static ITakeAndSkip<T> FirstTakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return new TakeAndSkip<T>(source).ThenTakeWhile(predicate);
        }
        
        public static ITakeAndSkip<T> FirstSkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return new TakeAndSkip<T>(source).ThenSkipWhile(predicate);
        }
    }
