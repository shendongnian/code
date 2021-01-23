    static public class RecursionExtensions
    {
        static public IEnumerable<T> AllDescendants<T>(this IEnumerable<T> source, 
                                                    Func<T, IEnumerable<T>> descender)
        {
            foreach (T value in source)
            {
                yield return value;
    
                foreach (T child in descender(value).AllDescendants<T>(descender))
                {
                    yield return child;
                }
            }
        }
    }
