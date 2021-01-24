    public class Grid<T>
    {
        private T[] _gridArray;  
  
        public Grid(int size)
        {
            _gridArray = new T[size];
        }            
        public Grid(int size, T initialValue)
        {
            _gridArray = new T[size];
            for (int i = 0; i < size; i++)
                _gridArray[i] = initialValue;
 
            // or it can be rewritten with LINQ, if you like:
            // _gridArray = Enumerable.Repeat(initialValue, size).ToArray();
        }    
    }
