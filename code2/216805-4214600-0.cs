    using System.Reflection;
    using System.Security;
    protected const string AUTHORIZED_CALLER
        = "YourTrustedAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bb5a56c4391e80f";
    public void MyMethod()
    {
        if (Assembly.GetCallingAssembly().FullName != AUTHORIZED_CALLER) {
            throw new SecurityException("Unauthorized method call.");
        }
        // Now do something.
    }
