    public class Example : DynamicObject
    {
        public Dictionary<string, string> Dict { get; } = new Dictionary<string, string>() { ["Foo"] = "bar" };
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (!Dict.TryGetValue(binder.Name, out var value))
                return false;
            result = value;
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (Dict.ContainsKey(binder.Name))
            {
                Dict[binder.Name] = value?.ToString();
                return true;
            }
            return Dict.TryAdd(binder.Name, value?.ToString());
        }
    }
