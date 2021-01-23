    public class Foo : DynamicObject
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();
        public Foo(params object[] args)
        {
            foreach (object arg in args)
            {
                data.Add(arg.ToString(), "..");
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (data.ContainsKey(binder.Name))
            {
                result = data[binder.Name];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    }
