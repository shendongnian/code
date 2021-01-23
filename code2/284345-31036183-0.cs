    public class ConcurrentDeck<T>
    {
       private readonly int _size;
       private readonly T[] _buffer;
       private int _position = 0;
    
       public ConcurrentDeck(int size)
       {
           _size = size;
           _buffer = new T[size];
       }
    
       public void Push(T item)
       {
           lock (this)
           {
               _buffer[_position] = item;
               _position++;
               if (_position == _size) _position = 0;
           }
       }
    
       public T[] ReadDeck()
       {
           lock (this)
           {
               return _buffer.Skip(_position).Union(_buffer.Take(_position)).ToArray();
           }
       }
    }
