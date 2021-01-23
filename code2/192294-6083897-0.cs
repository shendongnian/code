    // Spew all references to obj throughout the object hierarchy.
    public static void FindReferences( object appRootObject, object obj )
    {
    	Stack<ReferencePath> stack = new Stack<ReferencePath>();
    	FindReferences_R( stack, appRootObject, obj );
    }
    struct ReferencePath
    {
    	public ReferencePath( object parentObj, FieldInfo parentField )
    	{
    		m_ParentObject = parentObj;
    		m_ParentField = parentField;
    	}
    
    	public object m_ParentObject;
    	public FieldInfo m_ParentField;
    }
    
    static void PrintReferencePath( Stack< ReferencePath > stack )
    {
    	string s = "RootObject";
    	foreach ( ReferencePath path in stack.ToArray().Reverse() )
    	{
    		s += "." + path.m_ParentField.Name;
    	}
    	System.Console.WriteLine( s );
    }
    
    static bool StackContainsParent( Stack< ReferencePath > stack, object obj )
    {
    	foreach ( ReferencePath path in stack )
    	{
    		if ( path.m_ParentObject == obj )
    			return true;
    	}
    
    	return false;
    }
    
    static void FindReferences_R( Stack< ReferencePath > stack, object curParent, object obj )
    {
    	Type parentType = curParent.GetType();
    
    	foreach ( MemberInfo memberInfo in parentType.GetMembers() )
    	{
    		FieldInfo fieldInfo = memberInfo as FieldInfo;
    		if ( fieldInfo == null )
    			continue;
    
    		Type fieldType = fieldInfo.FieldType;
    		if ( !fieldType.IsClass )
    			continue;
    
    		object value = fieldInfo.GetValue( curParent );
    		if ( value == null )
    			continue;
    				
    		stack.Push( new ReferencePath( curParent, fieldInfo ) );
    		if ( value == obj )
    		{
    			PrintReferencePath( stack );
    		}
    
    		// Recurse, but don't recurse forever.
    		if ( !StackContainsParent( stack, value ) )
    		{
    			FindReferences_R( stack, value, obj );
    		}
    
    		stack.Pop();
    	}
    }
    
