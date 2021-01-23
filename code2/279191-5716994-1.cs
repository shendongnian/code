    var parent = new ParentEntity() { Id = 1 };
    context.Parents.Attach(parent);
    var child = new ChildEntity() {Id = 1};
    child.Parent = parent;  // <-- Assigning only navigation property
    // Next line will cause InvalidOperationException:
    // A referential integrity constraint violation occurred: 
    // The property values that define the referential constraints 
    // are not consistent between principal and dependent objects in 
    // the relationship.
    context.Childs.Attach(child);
    context.Entry(child).State = EntityState.Modified;
    context.SaveChanges();
