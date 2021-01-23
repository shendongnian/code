    var m = Do(typeof(B));
    
    public object Do(Type t)
    { 
       dynamic builder = ObjectFactory.GetInstance(t);
       return builder.Create("");
    }
