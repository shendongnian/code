    List<object> o = new List<object>();
    o.Add("one");
    o.Add("two");
    o.Add(3);
    
    IEnumerable<string> s1 = o.Cast<string>(); //fails on the 3rd item
    List<string> s2 = o.ConvertAll(x => x.ToString()); //succeeds
