    #define IMPLICIT_CONVERSIONS
    using System.Collections.Generic;
    
    namespace NS
    {
    	public enum PositionEnum : int { Begin = 0, Normal = 1, End = 99 }
    
    	public struct Pseudo<T> where T : struct
    	{
    		public T Value;
    		public Pseudo(T value) { Value = value; }
    #if IMPLICIT_CONVERSIONS
    		public static implicit operator T(Pseudo<T> pi)  { return pi.Value; }
    		public static implicit operator Pseudo<T>(T ni)  { return new Pseudo<T>(ni); }
    #endif
    	}
    
    	static class Program
    	{
    		private static Pseudo<T> AsPseudo<T>(this T value) where T : struct
    		{
    			return new Pseudo<T>(value);
    		}
    
    		private static readonly IDictionary<Pseudo<int>, string> _byInt = 
    			new Dictionary<Pseudo<int>, string>()
    				{	{ 0,  "aap" },
    					{ 1,  "noot" },
    					{ 99, "mies" },
    				};
    
    		private static readonly IDictionary<Pseudo<PositionEnum>, string> _byEnum = 
    			new Dictionary<Pseudo<PositionEnum>, string>()
    				{	{ PositionEnum.Begin,  "aap" },
    					{ PositionEnum.Normal, "noot" },
    					{ PositionEnum.End,    "mies" },
    				};
    
    		public static void Main(string[] args)
    		{
    			string s;
    			s = _byInt[0];
    			s = _byEnum[PositionEnum.Normal];
    		}
    	}
    }
    	
