    private static bool isPublic(Type t) {
    	return
    		t.IsVisible
    		&& t.IsPublic
    		&& !t.IsNotPublic
    		&& !t.IsNested
    		&& !t.IsNestedPublic
    		&& !t.IsNestedFamily
    		&& !t.IsNestedPrivate
    		&& !t.IsNestedAssembly
    		&& !t.IsNestedFamORAssem
    		&& !t.IsNestedFamANDAssem;
    }
    
    private static bool isInternal(Type t) {
    	return
    		!t.IsVisible
    		&& !t.IsPublic
    		&& t.IsNotPublic
    		&& !t.IsNested
    		&& !t.IsNestedPublic
    		&& !t.IsNestedFamily
    		&& !t.IsNestedPrivate
    		&& !t.IsNestedAssembly
    		&& !t.IsNestedFamORAssem
    		&& !t.IsNestedFamANDAssem;
    }
    
    // only nested types can be declared "protected"
    private static bool isProtected(Type t) {
    	return
    		!t.IsVisible
    		&& !t.IsPublic
    		&& !t.IsNotPublic
    		&& t.IsNested
    		&& !t.IsNestedPublic
    		&& t.IsNestedFamily
    		&& !t.IsNestedPrivate
    		&& !t.IsNestedAssembly
    		&& !t.IsNestedFamORAssem
    		&& !t.IsNestedFamANDAssem;
    }
    
    // only nested types can be declared "private"
    private static bool isPrivate(Type t) {
    	return
    		!t.IsVisible
    		&& !t.IsPublic
    		&& !t.IsNotPublic
    		&& t.IsNested
    		&& !t.IsNestedPublic
    		&& !t.IsNestedFamily
    		&& t.IsNestedPrivate
    		&& !t.IsNestedAssembly
    		&& !t.IsNestedFamORAssem
    		&& !t.IsNestedFamANDAssem;
    }
