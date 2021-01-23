    foreach(string[,] square in cross)
        for(int y = 0; y < square.GetUpperBound(0); y++){
            var inner = new IndexedInner(square, y);
            // now do something with inner
        }
    ...
    // this class should really implement ICollection<T> and System.Collections.IList,
    // but that would be too much unimportant code to put here
    class IndexedInner<T> : IEnumerable<T>{
        T[,] square;
        int  y;
        public IndexedInner(T[,] square, int y){
            this.square = square;
            this.y      = y;
        }
        public int Length{get{return square.GetLength(1);}}
        public T this[int x]{
            get{return square[y, x];}
            set{square[y, x] = value;}
        }
        public IEnumerator<T> GetEnumerator(){
            for(int x = 0; x < square.GetUpperBound(1); x++)
                yield return square[y, x];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }
    }
