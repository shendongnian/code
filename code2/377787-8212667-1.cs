	static void RemoveButFirst(object o){
			
		Type t = o.GetType();
			
		System.Reflection.MethodInfo rm = t.GetMethod("RemoveAt",
                                                     new Type[]{typeof(int)});
		System.Reflection.PropertyInfo count = t.GetProperty("Count");
 
		for (int n = (int)(count.GetValue(o,null)) ; n>1; n--)
		    rm.Invoke(o, new object[]{n-1});
		
	}	
