    using System;
    using System.Collections.Generic;
    public class A
    {
 	    public int someParameter;
    }
    public class B : A {}
    public class C : A {}
    public class D : A {}
    
    public class Program
    {
    	public static void Main()
    	{
    		List <Type> listOfSubClasses = new List<Type>
    		{
    			typeof(B),
    			typeof(C),
    			typeof(D)
    		};
    		List <A> objects = new List<A>();
    		int[] variable = { 1, 2, 3 }; 
    		foreach (var subClass in listOfSubClasses) {
    			for (int i = 0; i < 3; i++) {
    				objects.Add((A)Activator.CreateInstance(subClass));
                    objects[objects.Count - 1].someParameter = variable[i];
    			}
    		}
    	}
    }
