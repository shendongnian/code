    foreach (var temp in ParentThings) 
    {
        var parentThing = temp;
        Context.Load(Context.GetChildThingForParentQuery(parentThing.Id), op =>
            {
                parentThing.Child = op.Entities.FirstOrDefault();
            }, null);
    }
