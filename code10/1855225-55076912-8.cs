    public class Grid<T>
    {
    	private static readonly Dictionary<Type, object> _customDefaultValues = new Dictionary<Type, object>
    	{
    		[typeof(int)] = -1,
            [typeof(long)] = long.MaxValue
    	};
    
        public T[] _gridArray;  
    
        public Grid(int size)
        {
            _gridArray = new T[size];
    		
    		if (_customDefaultValues.TryGetValue(typeof(T), out object defaultValue))
    		{
    			T defaultValueUnboxed = (T)defaultValue;
    			for (int i = 0; i < size; i++)
    				_gridArray[i] = defaultValueUnboxed;
    		}
        }  
    }
 
    var grid = new Grid<int>(4); // [-1, -1, -1, -1]
    var grid = new Grid<long>(2); // [long.MaxValue, long.MaxValue]
    var grid = new Grid<bool>(3); // [false, false, false]
