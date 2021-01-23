    public static class Check<T>
    {
    			public static readonly Predicate<T> IfNull = CreateIfNullDelegate();
    			private static bool AlwaysFalse(T obj)
    			{
    				return false;
    			}
    
    			private static bool ForRefType(T obj)
    			{
    				return object.ReferenceEquals(obj, null);
    			}
    
    			private static bool ForNullable<Tu>(Tu? obj) where Tu:struct
    			{
    				return !obj.HasValue;
    			}
    			private static Predicate<T> CreateIfNullDelegate()
    			{
    				if (!typeof(T).IsValueType)
    					return ForRefType;
    				else
    				{
    					Type underlying;
    					if ((underlying = Nullable.GetUnderlyingType(typeof(T))) != null)
    					{
    						return Delegate.CreateDelegate(
    							typeof(Predicate<T>),
    							typeof(Check<T>)
    								.GetMethod("ForNullable",BindingFlags.NonPublic | BindingFlags.Static)
    									.MakeGenericMethod(underlying)
    						) as Predicate<T>;
    					}
    					else
    					{
    						return AlwaysFalse;
    					}
    				}
    			}
    		}
