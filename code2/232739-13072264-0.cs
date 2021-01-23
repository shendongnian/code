    public class SubArray<T> {
        private ArraySegment<T> segment;
        public SubArray(T[] array, int offset, int count) {
            segment = new ArraySegment<T>(array, offset, count);
        }
        public int Count {
            get { return segment.Count; }
        }
        public T this[int index] {
            get {
                int idx = segment.Offset + index;
                if (idx > segment.Array.Length - 1 || idx < 0) {
                    throw new IndexOutOfRangeException("Index '" + index + "' was outside the bounds of the subarray.");
                }
                return segment.Array[idx];
            }
        }
        public IEnumerator<T> GetEnumerator() {
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++) {
                yield return segment.Array[i];
            }
        }
    } //end of the class
