    public override bool TryInvokeMember(
        InvokeMemberBinder binder, object[] args, out object result)
    {
        var innerBinder = Binder.InvokeMember(
            CSharpBinderFlags.None, binder.Name, null, null,
            new[]
            {
                CSharpArgumentInfo.Create(
                    CSharpArgumentInfoFlags.UseCompileTimeType
                    | CSharpArgumentInfoFlags.IsStaticType, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
            });
        var callSite = CallSite<Func<CallSite, object, object, object>>
            .Create(innerBinder);
        try
        {
            result = callSite.Target(callSite, m_type, args[0]);
            return true;
        }
        catch (RuntimeBinderException)
        {
            result = null;
            return false;
        }
    }
