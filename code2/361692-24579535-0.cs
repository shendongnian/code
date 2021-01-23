	You can do it by extending the HashSet, meat of it to see if it contains the element, and thats O(1), reaturn that 	element, so no harm done in that case. Here is the derived one:
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    namespace Tester
    {
        // Summary:
        //     Represents a set of values.
        //
        // Type parameters:
        //   T:
        //     The type of elements in the hash set.
        [Serializable]
        public class HashSetExt<T> : HashSet<T>
        {
            // Summary:
            //     Initializes a new instance of the System.Collections.Generic.HashSetExt<T> class
            //     that is empty and uses the default equality comparer for the set type.
            public HashSetExt() : base() { }
            public HashSetExt(IEnumerable<T> collection) : base(collection) { }
            public HashSetExt(IEqualityComparer<T> comparer) : base(comparer) { }
            public HashSetExt(IEnumerable<T> collection, IEqualityComparer<T> comparer) : base(collection, comparer) { }
            protected HashSetExt(SerializationInfo info, StreamingContext context) : base(info, context) { }
            public T this[T item]
            {
                get
                {
                    if (this.Contains(item))
                    {
                        return item;
                    }
                    throw new KeyNotFoundException();
                }
            }
        }
    }
