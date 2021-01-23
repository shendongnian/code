    public class Expando : DynamicObject
    {
        public dynamic Instance;
        Dictionary<string, dynamic> ExtraProperties = new Dictionary<string, dynamic>();
        public Expando(object instance)
        {
            Instance = instance;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = ReflectionUtils.GetProperty(Instance, binder.Name);
                return true;
            }
            catch
            {
                if (ExtraProperties.Keys.Contains(binder.Name))
                {
                    result = ExtraProperties[binder.Name];
                    return true;
                }
            }
            result = null;
            return false;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                ReflectionUtils.SetProperty(Instance, binder.Name, value);
            }
            catch (Exception ex)
            {
                ExtraProperties[binder.Name] = value;
            }
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = ReflectionUtils.CallMethod(Instance, binder.Name, args);
                return true;
            }
            catch
            {}
            result = null;
            return false;
        }
    }
