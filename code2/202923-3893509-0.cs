    foo_entitiesctx = new foo_entities(new Uri("http://url/FooService.svc/"));
    ctx.MergeOption = MergeOption.AppendOnly;
    var collections = from pi in typeof(TestResult).GetProperties()
                       where IsSubclassOfRawGenericCollection(pi.PropertyType)
                       select pi.Name;
    var things = ctx.Things.Expand(string.Join(",", collections));
    foreach (var item in things)
    {
        foreach (var child in item.ChildCollectionProperty1)
        {
            //do thing
        }
    }  
