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
        }    
    }
    public static class GridFactory
    {
    	private static readonly Dictionary<Type, object> _customDefaultValues = new Dictionary<Type, object>
    	{
    		[typeof(int)] = -1,
            [typeof(long)] = long.MaxValue
    	};
    	
    	public static Grid<T> Create<T>(int size)
    	{
    		if (_customDefaultValues.TryGetValue(typeof(T), out object defaultValue))
    			return new Grid<T>(size, (T)defaultValue);
    		
    		return new Grid<T>(size);
    	}        
    }
