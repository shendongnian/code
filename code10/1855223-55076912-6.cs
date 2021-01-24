    public class Grid<T>
    {
        private T[] _gridArray;  
    
        private Grid(int size)
        {
            _gridArray = new T[size];
        }            
    
        private Grid(int size, T initialValue)
        {
            _gridArray = new T[size];
            for (int i = 0; i < size; i++)
                _gridArray[i] = initialValue;
    
            // or it can be rewritten with LINQ, if you like:
            // _gridArray = Enumerable.Repeat(initialValue, size).ToArray();
        }    
    	
    	// Factory:
    	private static readonly Dictionary<Type, object> _customDefaultValues = new Dictionary<Type, object>
    	{
    		[typeof(int)] = -1,
            [typeof(long)] = long.MaxValue
    	};
    	
    	public static Grid<T> Create(int size)
    	{
    		if (_customDefaultValues.TryGetValue(typeof(T), out object defaultValue))
    			return new Grid<T>(size, (T)defaultValue);
    		
    		return new Grid<T>(size);
    	}
    }
