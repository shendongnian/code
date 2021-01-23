    if(Binder.IsEvent("OnMyEvent", typeof(SomeWrapperClass)))
    {
        Binder.InvokeMember("add_OnMyEvent", myAction);
    }
    else
    {
        var e = Binder.GetMember("OnMyEvent");
        var ae = Binder.BinaryOperation(ExpressionType.AddAssign, e, myAction);
        Binder.SetMember("OnMyEvent", ae);
    }
