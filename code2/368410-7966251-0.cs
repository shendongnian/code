    static object InvokeMethod(Delegate method){
        try{
            method.DynamicInvoke();
        } catch (Exception e)
        {}
    }
    
    static void Test(){
        InvokeMethod(new Func<>(ExternalDevice.Call1));
    }
