    if(objects == null) throw new ArgumentException();
    using(var iter = objects.GetEnumerator()) {
        if(!iter.MoveNext()) throw new ArgumentException();
        var firstObject = iter.Current;
        var list = DoSomeThing(firstObject);  
        while(iter.MoveNext()) {
            list.Add(DoSomeThingElse(iter.Current));
        }
        return list;
    }
