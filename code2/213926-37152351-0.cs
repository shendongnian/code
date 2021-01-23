    void Test(){
        var obj = new{a="aaa", b="bbb"};
        var val_a = obj.GetValObjDy("a"); //="aaa"
        var val_b = obj.GetValObjDy("b"); //="bbb"
    }
    //create in a static class
    static public object GetValObjDy(this object obj, string propertyName)
    {            
         return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
    }
