    using System.Diagnostics.Contracts; // required namespace 
    public T MethodName()
    {
        Contract.Ensures(Contract.Result<T>() != null); //where T is the return type.
        // method body...
    }
