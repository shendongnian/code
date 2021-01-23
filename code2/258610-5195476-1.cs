    interface ICommonFunctions
    {
       void MethodA();
    
       void MethodB();
    }
    
    class ProxyRefA : ICommonFunctions
    {
        refA proxyObj = new refA;
        void MethodA() { proxyObj.methodWithOtherName(); }
    
        void MethodB() { proxyObj.otherMethodName(); }
    }
    /* The same for refB and refC */
