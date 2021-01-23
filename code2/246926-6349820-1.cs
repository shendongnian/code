    public delegate object AnonymousDelegate();
     
    public static object GetDelegateResult(AnonymousDelegate function)
    {
        return function.Invoke();
    }
    
