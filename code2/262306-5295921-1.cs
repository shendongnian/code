    class DynamicString : DynamicObject
    {
        class DynamicStringMetaObject : DynamicMetaObject
        {
            public DynamicStringMetaObject(Expression parameter, object value)
                : base(parameter, BindingRestrictions.Empty, value)
            {
            }
            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                if (binder.Type == typeof(string))
                {
                    var valueType = Value.GetType();
                    return new DynamicMetaObject(
                        Expression.MakeMemberAccess(
                            Expression.Convert(Expression, valueType),
                            valueType.GetProperty("Instance")),
                        BindingRestrictions.GetTypeRestriction(Expression, valueType));
                }
                return base.BindConvert(binder);
            }
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("BindGetMember: {0}", binder.Name));
                var valueType = Value.GetType();
                var self = Expression.Convert(Expression, valueType);
                var valueMembers = valueType.GetMember(binder.Name);
                if (valueMembers.Length > 0)
                {
                    return BindGetMember(self, valueMembers.Single());
                }
                var members = typeof(string).GetMember(binder.Name);
                if (members.Length > 0)
                {
                    var instance =
                        Expression.MakeMemberAccess(
                            self,
                            valueType.GetProperty("Instance"));
                    return BindGetMember(instance, members.Single());
                }
                return base.BindGetMember(binder);
            }
            private DynamicMetaObject BindGetMember(Expression instance, MemberInfo member)
            {
                return new DynamicMetaObject(
                    Expression.Convert(
                        Expression.MakeMemberAccess(instance, member),
                        typeof(object)),
                    BindingRestrictions.GetTypeRestriction(Expression, Value.GetType())
                );
            }
        }
        public string Instance { get; private set; }
        public DynamicString(string instance)
        {
            Instance = instance;
        }
        public override DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new DynamicStringMetaObject(parameter, this);
        }
        public override string ToString()
        {
            return Instance;
        }
        public string GetPrefixString(string prefix)
        {
            return String.Concat(prefix, Instance);
        }
        public string GetSuffixString(string suffix)
        {
            return String.Concat(Instance, suffix);
        }
    }
