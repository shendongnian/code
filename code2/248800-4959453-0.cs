    Type t = Type.GetType("castToTypeNameHere");
    
    //using dynamic
    dynamic obj = Convert.ChangeType(objectToCast, t);
    obj.SomeExpectedMethod(); 
    
    //casting to known interface
    var obj = Convert.ChangeType(objectToCast, t) as IKnowWhatImSupposedToBe;
    if (obj == null) HandleBadState();
