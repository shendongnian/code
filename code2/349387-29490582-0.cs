    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    // Based on source: http://jonskeet.uk/csharp/miscutil/
    
    namespace Generic.Utilities
    {
        /// <summary>
        /// Static class to make creation easier. If possible though, use the extension
        /// method in SmartEnumerableExt.
        /// </summary>
        public static class SmartEnumerable
        {
            /// <summary>
            /// Extension method to make life easier.
            /// </summary>
            /// <typeparam name="T">Type of enumerable</typeparam>
            /// <param name="source">Source enumerable</param>
            /// <returns>A new SmartEnumerable of the appropriate type</returns>
            public static SmartEnumerable<T> Create<T>(IEnumerable<T> source)
            {
                return new SmartEnumerable<T>(source);
            }
        }
    
        /// <summary>
        /// Type chaining an IEnumerable&lt;T&gt; to allow the iterating code
        /// to detect the first and last entries simply.
        /// </summary>
        /// <typeparam name="T">Type to iterate over</typeparam>
        public class SmartEnumerable<T> : IEnumerable<SmartEnumerable<T>.Entry>
        {
    
            /// <summary>
            /// Enumerable we proxy to
            /// </summary>
            readonly IEnumerable<T> enumerable;
    
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="enumerable">Collection to enumerate. Must not be null.</param>
            public SmartEnumerable(IEnumerable<T> enumerable)
            {
                if (enumerable == null)
                {
                    throw new ArgumentNullException("enumerable");
                }
                this.enumerable = enumerable;
            }
    
            /// <summary>
            /// Returns an enumeration of Entry objects, each of which knows
            /// whether it is the first/last of the enumeration, as well as the
            /// current value and next/previous values.
            /// </summary>
            public IEnumerator<Entry> GetEnumerator()
            {
                using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        yield break;
                    }
                    bool isFirst = true;
                    bool isLast = false;
                    int index = 0;
                    Entry previous = null;
    
                    T current = enumerator.Current;
                    isLast = !enumerator.MoveNext();
                    var entry = new Entry(isFirst, isLast, current, index++, previous);                
                    isFirst = false;
                    previous = entry;
    
                    while (!isLast)
                    {
                        T next = enumerator.Current;
                        isLast = !enumerator.MoveNext();
                        var entry2 = new Entry(isFirst, isLast, next, index++, entry);
                        entry.SetNext(entry2);
                        yield return entry;
    
                        previous.UnsetLinks();
                        previous = entry;
                        entry = entry2;                    
                    }
    
                    yield return entry;
                    previous.UnsetLinks();
                }
            }
    
            /// <summary>
            /// Non-generic form of GetEnumerator.
            /// </summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            /// <summary>
            /// Represents each entry returned within a collection,
            /// containing the value and whether it is the first and/or
            /// the last entry in the collection's. enumeration
            /// </summary>
            public class Entry
            {
                #region Fields
                private readonly bool isFirst;
                private readonly bool isLast;
                private readonly T value;
                private readonly int index;
                private Entry previous;
                private Entry next = null;
                #endregion
    
                #region Properties
                /// <summary>
                /// The value of the entry.
                /// </summary>
                public T Value { get { return value; } }
    
                /// <summary>
                /// Whether or not this entry is first in the collection's enumeration.
                /// </summary>
                public bool IsFirst { get { return isFirst; } }
    
                /// <summary>
                /// Whether or not this entry is last in the collection's enumeration.
                /// </summary>
                public bool IsLast { get { return isLast; } }
    
                /// <summary>
                /// The 0-based index of this entry (i.e. how many entries have been returned before this one)
                /// </summary>
                public int Index { get { return index; } }
    
                /// <summary>
                /// Returns the previous entry.
                /// Only available for the CURRENT entry!
                /// </summary>
                public Entry Previous { get { return previous; } }
                /// <summary>
                /// Returns the next entry for the current iterator.
                /// Only available for the CURRENT entry!
                /// </summary>
                public Entry Next { get { return next; } }
                #endregion
    
                #region Constructors
                internal Entry(bool isFirst, bool isLast, T value, int index, Entry previous)
                {
                    this.isFirst = isFirst;
                    this.isLast = isLast;
                    this.value = value;
                    this.index = index;
                    this.previous = previous;
                }
                #endregion
    
                #region Methods
                /// <summary>
                /// Fix the link to the next item of the IEnumerable
                /// </summary>
                /// <param name="entry"></param>
                internal void SetNext(Entry entry)
                {
                    next = entry;
                }
    
                /// <summary>
                /// Allow previous and next Entry to be garbage collected by setting them to null
                /// </summary>
                internal void UnsetLinks()
                {
                    previous = null;
                    next = null;
                }
    
                /// <summary>
                /// Returns "(index)value"
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                    return String.Format("({0}){1}", Index, Value);
                }
                #endregion
            }
        }
    }
