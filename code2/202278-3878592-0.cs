    public static dynamic Maybe(this object target)
    {
        return new MaybeObject(target);
    }
    private class MaybeObject : DynamicObject
    {
        private readonly object _target;
        public MaybeObject(object target)
        {
            _target = target;
        }
        public override bool TryGetMember(GetMemberBinder binder,
                                          out object result)
        {
            result = _target != null ? Execute<object>(binder).Maybe() : this;
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder,
                                             object[] args, out object result)
        {
            if (binder.Name == "Maybe" &&
                binder.ReturnType == typeof (object) &&
                binder.CallInfo.ArgumentCount == 0)
            {
                // skip extra calls to Maybe
                result = this;
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (_target != null)
            {
                // call Execute with an appropriate return type
                result = GetType()
                    .GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(binder.ReturnType)
                    .Invoke(this, new object[] {binder});
            }
            else
            {
                result = null;
            }
            return true;
        }
        private object Execute<T>(CallSiteBinder binder)
        {
            var site = CallSite<Func<CallSite, object, T>>.Create(binder);
            return site.Target(site, _target);
        }
    }
