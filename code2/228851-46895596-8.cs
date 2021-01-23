    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    
    class Tree : DynamicObject
    {
        private IDictionary<object, object> dict = new Dictionary<object, object>();
    
        // for t.first.second.third syntax
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
    
        // for t["first"]["second"]["third"] syntax
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var key = indexes[0];
    
            if (dict.ContainsKey(key))
                result = dict[key];
            else
                dict[key] = result = new Tree();
    
            return true;
        }
    
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            dict[indexes[0]] = value;
            return true;
        }
    }
    
    // Test:
    dynamic t = new Tree();
    t.first.second.third = "text";
    Console.WriteLine(t.first.second.third);
    
    // or,
    dynamic t = new Tree();
    t["first"]["second"]["third"] = "text";
    Console.WriteLine(t["first"]["second"]["third"]);
