    /// <summary>
    /// Use this class when you want to pull the first item off of an IEnumerable
    /// and then enumerate over the remaining elements and you want to avoid the
    /// warning about "possible double iteration of IEnumerable" AND without constructing
    /// a list or other duplicate data structure of the enumerable. You construct 
    /// this class from your existing IEnumerable and then use its First and 
    /// Remaining properties for your algorithm.
    /// </summary>
    /// <typeparam name="T">The type of item you are iterating over; there are no
    /// "where" restrictions on this type.</typeparam>
    public class SplitFirstEnumerable<T>
    {
        private readonly IEnumerator<T> _enumerator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Will throw an exception if there are zero items in enumerable or 
        /// if the enumerable is already advanced past the last element.</remarks>
        /// <param name="enumerable">The enumerable that you want to split</param>
        public SplitFirstEnumerable(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
            if (_enumerator.MoveNext())
            {
                First = _enumerator.Current;
            }
            else
            {
                throw new ArgumentException("Parameter 'enumerable' must have at least 1 element to be split.");
            }
        }
        /// <summary>
        /// The first item of the original enumeration, equivalent to calling
        /// enumerable.First().
        /// </summary>
        public T First { get; private set; }
        /// <summary>
        /// The items of the original enumeration minus the first, equivalent to calling
        /// enumerable.Skip(1).
        /// </summary>
        public IEnumerable<T> Remaining
        {
            get
            {
                while (_enumerator.MoveNext())
                {
                    yield return _enumerator.Current;
                }
            }
        }
    }
