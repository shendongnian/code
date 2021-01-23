    var obj = new MyInteracedClass();
    typeof(IMyInterface).IsAssignableFrom(obj.GetType());
    or
    
    typeof(IMyInterface).IsAssignableFrom(typeof(MyInteracedClass));
