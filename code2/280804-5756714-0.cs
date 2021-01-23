        #region ArraySegment related methods
        public static ArraySegment<T> GetSegment<T>(this T[] array, int from, int count)
        {
            return new ArraySegment<T>(array, from, count);
        }
        public static ArraySegment<T> GetSegment<T>(this T[] array, int from)
        {
            return GetSegment(array, from, array.Length - from);
        }
        public static ArraySegment<T> GetSegment<T>(this T[] array)
        {
            return new ArraySegment<T>(array);
        }
        public static IEnumerable<T> AsEnumerable<T>(this ArraySegment<T> arraySegment)
        {
            return arraySegment.Array.Skip(arraySegment.Offset).Take(arraySegment.Count);
        }
        public static T[] ToArray<T>(this ArraySegment<T> arraySegment)
        {
            T[] array = new T[arraySegment.Count];
            Array.Copy(arraySegment.Array, arraySegment.Offset, array, 0, arraySegment.Count);
            return array;
        }
        #endregion
