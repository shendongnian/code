    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace SilverlightApplication1
    {
    	public static class EnumValuesExtensions
    	{
    		public static Array GetEnumValues(this Type EnumType)
    		{
    			if (!EnumType.IsEnum)
    				throw new ArgumentException("GetEnumValues: Type '" + EnumType.Name + "' is not an enum");
    
    			return
    				(
    				  from field in EnumType.GetFields(BindingFlags.Public | BindingFlags.Static)
    				  where field.IsLiteral
    				  select (object)field.GetValue(null)
    				)
    				.ToArray();
    		}
    
    		public static string[] GetEnumNames(this Type EnumType)
    		{
    			if (!EnumType.IsEnum)
    				throw new ArgumentException("GetEnumNames: Type '" + EnumType.Name + "' is not an enum");
    
    			return
    				(
    				  from field in EnumType.GetFields(BindingFlags.Public | BindingFlags.Static)
    				  where field.IsLiteral
    				  select field.Name
    				)
    				.ToArray();
    		}
    	}
    }
