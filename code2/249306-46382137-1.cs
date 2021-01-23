    bool isPublic(Type t) {
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
    
    bool isInternal(Type t) {
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
    bool isProtected(Type t) {
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
    bool isPrivate(Type t) {
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
