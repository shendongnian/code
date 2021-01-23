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
    	
    	private static Size GetValue(DEF_TYPES def_type)
    	{
    		if(!m_Defs.ContainsKey(typeof(Size)))
    			throw new ArgumentException("No default values for template " + typeof(Size));
    		if(!m_Defs[typeof(Size)].ContainsKey(def_type))
    			throw new ArgumentException("No default value '" + def_type + "' for template " + typeof(Size));
    		return (Size)m_Defs[typeof(Size)][def_type];
    	}
    
    	public Size R;
    	public Size G;
    	public Size B;
    	public static readonly Size Min = GetValue(DEF_TYPES.MIN);
    	public static readonly Size Max = GetValue(DEF_TYPES.MAX);
    }
