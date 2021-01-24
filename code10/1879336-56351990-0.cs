    public class SplitList<T> where T : struct {
          // A virtual list divided into several sublists, removing the 2GB capacity limit 
    
          private List<T>[] _lists;
          private Queue<int> _free = new Queue<int>();
          private int _maxId = 0;
          private const int _hashingBits = 8;
          private const int _listSelector = 32 - _hashingBits;
          private const int _subIndexMask = (1 << _listSelector) - 1;
          
    
    
          public SplitList() {
             int listCount = 1 << _hashingBits;
             _lists = new List<T>[listCount];
             for( int i = 0; i < listCount; i++ )
                _lists[i] = new List<T>();
          }
    
          // Access a struct by index
          // Remember that this returns a local copy of the struct, so if changes are to be done, 
          // the local copy must be copied to a local struct,  modify it, and then copy back the changes
          // to the list
          public T this[int idx] {
             get {
                return _lists[(idx >> _listSelector)][idx & _subIndexMask];
             }
             set {
                _lists[idx >> _listSelector][idx & _subIndexMask] = value ;
             }
          }
    
    
          // returns an index to a "new" struct inside the collection
          public int New() {
    
             int result;
             T newElement = new T();
    
             // are there any free indexes available? 
             if( _free.Count > 0 ) {
                // yes, return a free index and initialize reused struct to default values
                result = _free.Dequeue();
                this[result] = newElement;
             } else {
                // no, grow the capacity
                result = ++_maxId;
                List<T> list = _lists[result >> _listSelector];
                list.Add(newElement);
             }
             return result;
          }
    
          // free an index and allow the struct slot to be reused.
          public void Free(int idx) {
             _free.Enqueue(idx);
          }
    
       }
