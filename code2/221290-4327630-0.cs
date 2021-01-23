    private CallMember()
    {
        Type t = typeof(Form1); //I guess I can also call 'myReferencedForm1.GetType();
        t.InvokeMember("SayHello",
                       System.Reflection.BindingFlags.InvokeMethod |
                       System.Reflection.BindingFlags.Instance |
                       System.Reflection.BindingFlags.NonPublic,
                       null, myReferencedForm1, new object[] { });
    }
