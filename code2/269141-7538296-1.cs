    using System;
    
    /**
     * Sam Sha - yCoder.com
     *
     * */
    namespace Test2
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string a = "ycoder";
    			Console.WriteLine(a is object);
    			A aa = new A();
    			//Console.WriteLine(aa is A<>);//con't write code like this
    			typeof(A<>).IsAssignableFrom(aa.GetType());//return false
    
    			Trace(typeof(object).IsAssignableFrom(typeof(string)));//true
    			Trace(typeof(A<>).IsAssignableFrom(typeof(A)));//false
    
    			AAA aaa = new AAA();
    			Trace("Use IsTypeOf:");
    			Trace(IsTypeOf(aaa, typeof(A<>)));
    			Trace(IsTypeOf(aaa, typeof(AA)));
    			Trace(IsTypeOf(aaa, typeof(AAA<>)));
    
    			Trace("Use IsAssignableFrom from stackoverflow - not right:");
    			Trace(IsAssignableFrom(typeof(A), typeof(A<>))); // error
    			Trace(IsAssignableFrom(typeof(AA), typeof(A<>)));
    			Trace(IsAssignableFrom(typeof(AAA), typeof(A<>)));
    
    			Trace("Use IsAssignableToGenericType:");
    			Trace(IsAssignableToGenericType(typeof(A), typeof(A<>)));
    			Trace(IsAssignableToGenericType(typeof(AA), typeof(A<>)));
    			Trace(IsAssignableToGenericType(typeof(AAA), typeof(A<>)));
    		}
    
    		static void Trace(object log){
    				Console.WriteLine(log);
    		}
    
    		public static bool IsTypeOf(Object o, Type baseType)
            {
                if (o == null || baseType == null)
                {
                    return false;
                }
                bool result = baseType.IsInstanceOfType(o);
                if (result)
                {
                    return result;
                }
                return IsAssignableFrom(o.GetType(), baseType);
            }
    
            public static bool IsAssignableFrom(Type extendType, Type baseType)
            {
                while (!baseType.IsAssignableFrom(extendType))
                {
                    if (extendType.Equals(typeof(object)))
                    {
                        return false;
                    }
                    if (extendType.IsGenericType && !extendType.IsGenericTypeDefinition)
                    {
                        extendType = extendType.GetGenericTypeDefinition();
                    }
                    else
                    {
                        extendType = extendType.BaseType;
                    }
                }
                return true;
            }
    
    		//from stackoverflow - not good enough
    		public static bool IsAssignableToGenericType(Type givenType, Type genericType) {
    		    var interfaceTypes = givenType.GetInterfaces();
    
    		    foreach (var it in interfaceTypes)
    		        if (it.IsGenericType)
    		            if (it.GetGenericTypeDefinition() == genericType) return true;
    
    		    Type baseType = givenType.BaseType;
    		    if (baseType == null) return false;
    
    		    return baseType.IsGenericType &&
    		        baseType.GetGenericTypeDefinition() == genericType ||
    		        IsAssignableToGenericType(baseType, genericType);
    		}
    	}
    
    	class A{}
    	class AA : A{}
    	class AAA : AA{}
    }
