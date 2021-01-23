    public class StaticWrapper<T> : System.Dynamic.DynamicObject
    {
        private static readonly Type t = typeof(T);
        public static int MyProperty { get; set; }
        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = t.InvokeMember(binder.Name, BindingFlags.Static | BindingFlags.Public, null, null, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            try
            {
                var p = t.GetProperty(binder.Name);
                if (p != null)
                    result = p.GetValue(null, null);
                else
                {
                    var f = t.GetField(binder.Name);
                    if (f != null) result = f.GetValue(null);
                    else { result = null; return false; }
                }
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
        {
            try
            {
                var p = t.GetProperty(binder.Name);
                if (p != null)
                    p.SetValue(null, value, null);
                else
                {
                    var f = t.GetField(binder.Name);
                    if (f != null) f.SetValue(null, value);
                    else return false;
                }
                return true;
            }
            catch (SystemException)
            {
                return false;
            }
        }
    }
