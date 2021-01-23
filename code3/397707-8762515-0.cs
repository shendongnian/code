    private void RunMethods(Type type)
    {
        foreach( var item in lstMethodList.SelectedItems )
        {
            foreach( var method in type.GetMethods() )
            {
                if( String.Equals( item.ToString(), method.Name))
                {
                    MethodInfo capturedMethod = method;
                    var t = new Thread( () => ThreadMain( type, capturedMethod ) );
                    t.Start();
                }
             }
         }
    }
	static void ThreadMain( Type type, MethodInfo mi )
	{
		object o = Activator.CreateInstance( type );
		object[] parameters = new object[] { };
		mi.Invoke( o, parameters );
	}
