    if(Binder.IsEvent("OnMyEvent", typeof(SomeWrapperClass)))
    {
        Binder.InvokeMember("add_OnMyEvent", obj, myAction);
    }
    else
    {
        var e = Binder.GetMember("OnMyEvent", obj);
        var ae = Binder.BinaryOperation(ExpressionType.AddAssign, e, myAction);
        Binder.SetMember("OnMyEvent", obj, ae);
    }
