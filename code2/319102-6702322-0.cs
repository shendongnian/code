    namespace ConsoleApplication1
    {
        /// <summary>
        /// See indexer <see cref="P:ConsoleApplication1.MyDictionary`2.Item(`0)"/>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public class MyDictionary<TKey, TValue>
        {
            /// <summary>
            /// Indexer
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public TValue this[TKey key]
            {
                get { return default(TValue); }
                set { }
            }
        }
    }
