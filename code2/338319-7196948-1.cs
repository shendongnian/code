    TypeDefinition type = ...;
    
    // public object get_Item (string str) { ... }
    var get_item = new MethodDefinition ("get_Item", MethodAttributes.Public, module.TypeSystem.Object);
    set_item.Parameters.Add (new ParameterDefinition ("str", ParameterAttributes.None, module.TypeSystem.String));
    type.Methods.Add (get_item);
    
    var il = get_item.Body.GetILProcessor ();
    il.Emit (...); // emit call to getObjectViaIndexer
    
    // public void set_Item (string str, object obj) { ... }
    var set_item = new MethodDefinition ("set_Item", MethodAttributes.Public, module.TypeSystem.Void);
    set_item.Parameters.Add (new ParameterDefinition ("str", ParameterAttributes.None, module.TypeSystem.String));
    set_item.Parameters.Add (new ParameterDefinition ("obj", ParameterAttributes.None, module.TypeSystem.Object));
    type.Methods.Add (set_item);
    
    il = set_item.Body.GetILProcessor ();
    il.Emit (...); // emit call to setObjectViaIndexer
    
    // public object this [string str] { ... }
    var item = new PropertyDefinition ("Item", PropertyAttributes.None, module.TypeSystem.Object) {
    	HasThis = true,
    	GetMethod = get_item,
    	SetMethod = set_item,
    };
    
    type.Properties.Add (item);
    
    // [DefaultMemberAttribute("Item")]
    var default_member = new CustomAttribute (module.Import (typeof (System.Reflection.DefaultMemberAttribute).GetConstructor (new [] { typeof (string) })));
    default_member.ConstructorArguments.Add (new CustomAttributeArgument(module.TypeSystem.String, "Item"));
    type.CustomAttributes.Add (default_member);
