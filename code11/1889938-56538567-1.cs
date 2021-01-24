         //unafe dynamic code here 
    }
    
    #pragma warning disable 0618
    public string PrintMe(Class1  obj) => InternalPrintMe(obj) ;
    public string PrintMe(Class2  obj) => InternalPrintMe(obj) ;
    #pragma warning disable 0618
