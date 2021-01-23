    public void MethodToCallInThread(string param1, string param2)
    {
        ...
    }
    public void HelperMethod(object helper){
        var h = (HelperObject) helper;
        MethodToCallInThread(h.param1, h.param2);
    }
