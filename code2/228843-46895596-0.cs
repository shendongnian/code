    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    
    class Tree : DynamicObject
    {
        IDictionary<string, object> dict = new Dictionary<string, object>();
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var key = binder.Name;
    
            if (dict.ContainsKey(key))
                result = dict[key];
            else
                dict[key] = result = new Tree();
            
            return true;
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dict[binder.Name] = value;
            return true;
        }
    }
    
    // Test:
    dynamic a = new Tree();
    a.first.second.third = "text";
    Console.WriteLine(a.first.second.third);
