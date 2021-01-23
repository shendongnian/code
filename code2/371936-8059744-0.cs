    public struct Pixel<Size> where Size : struct
    {
    	private enum DEF_TYPES
    	{
    		MIN,
    		MAX
    	}
    
    	private static Dictionary<Type, Dictionary<DEF_TYPES, object>> m_Defs = new Dictionary<Type, Dictionary<DEF_TYPES, object>>
    	{
    		{
    			typeof(float),
    				new Dictionary<DEF_TYPES, object> {
    					{DEF_TYPES.MIN, 0f},
    					{DEF_TYPES.MAX, 1f}
    				}
    		},
    		
    		{
    			typeof(double),
    				new Dictionary<DEF_TYPES, object> {
    					{DEF_TYPES.MIN, 0d},
    					{DEF_TYPES.MAX, 1d}
    				}
    		}
    	};
    	
    	private static T GetValue<T>(DEF_TYPES def_type)
    	{
    		if(!m_Defs.ContainsKey(typeof(T)))
    			throw new ArgumentException("No default values for template " + typeof(T));
    		if(!m_Defs[typeof(T)].ContainsKey(def_type))
    			throw new ArgumentException("No default value '" + def_type + "' for template " + typeof(T));
    		return (T)m_Defs[typeof(T)][def_type];
    	}
    
    	public Size R;
    	public Size G;
    	public Size B;
    	public static readonly Size Min = GetValue<Size>(DEF_TYPES.MIN);
    	public static readonly Size Max = GetValue<Size>(DEF_TYPES.MAX);
    }
