     // Use MethodInfo instead of Func in HandlerId
     public MethodInfo Method { get; set; }
    
     // Create the static list of handlers
     protected static HandlerID[] HandlerIDs = {    
      new SectionRenderer() { ID = SectionTypes.Type1, Method = typeof(MyHandlersClass).GetMethod("MyType1Handler") },    
      new SectionRenderer() { ID = SectionTypes.Type2, Method = typeof(MyHandlersClass).GetMethod("MyType2Handler") },    
       // Etc.
      }
    
      // invoke at some point
      HandlersIds[0].Method.Invoke(aninstanceobject, new object[] { arg } );
   
