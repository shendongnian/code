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
                   return segment.Array[segment.Offset + index];
                }
            }
    
            public T[] ToArray() {
                T[] temp = new T[segment.Count];
                Array.Copy(segment.Array, segment.Offset, temp, 0, segment.Count);
                return temp;
            }
    
            public IEnumerator<T> GetEnumerator() {
                for (int i = segment.Offset; i < segment.Offset + segment.Count; i++) {
                    yield return segment.Array[i];
                }
            }
        } //end of the class
    
