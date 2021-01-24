        /// <summary>
        /// A Function to compute the difference between two lists and returns the added and removed items
        ///  Removed = Old - New
        ///  Added = New - Old
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Old List</param>
        /// <param name="otherList">New List</param>
        /// <returns>Named Tuple of Added and Removed Items</returns>
        public static (List<T> added,List<T> removed) Difference<T>(this List<T> list, List<T> otherList,IEqualityComparer<T> comparer)
        {
            var removed = list.Except(otherList, comparer).ToList();
            var added = otherList.Except(list, comparer).ToList();
            return  (added:added,removed:removed);
        }
