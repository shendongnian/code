    class DynamicString : DynamicObject
    {
        static readonly Type strType = typeof(string);
        private string instance;
        private Dictionary<string, object> dynProperties;
        public DynamicString(string instance)
        {
            this.instance = instance;
            dynProperties = new Dictionary<string, object>();
        }
        public string GetPrefixString(string prefix)
        {
            return String.Concat(prefix, instance);
        }
        public string GetSuffixString(string suffix)
        {
            return String.Concat(instance, suffix);
        }
        public override string ToString()
        {
            return instance;
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type != typeof(string))
                return base.TryConvert(binder, out result);
            result = instance;
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var method = strType.GetMethod(binder.Name, args.Select(a => a.GetType()).ToArray());
            if (method == null)
            {
                result = null;
                return false;
            }
            result = method.Invoke(instance, args);
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var members = strType.GetMember(binder.Name);
            if (members.Length > 0)
            {
                var member = members.Single();
                switch (member.MemberType)
                {
                case MemberTypes.Property:
                    result = ((PropertyInfo)member).GetValue(instance, null);
                    return true;
                    break;
                case MemberTypes.Field:
                    result = ((FieldInfo)member).GetValue(instance);
                    return true;
                    break;
                }
            }
            return dynProperties.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var ret = base.TrySetMember(binder, value);
            if (ret) return true;
            dynProperties[binder.Name] = value;
            return true;
        }
    }
