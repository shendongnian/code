    var parent = new ParentEntity() { Id = 1 };
    context.Parents.Attach(parent);
    var child = new ChildEntity() {Id = 1};
    child.Parent = parent;
    child.ParentEntityId = 1; // <-- AGAIN assigning FK
    context.Childs.Attach(child);
    context.Entry(child).State = EntityState.Modified;
    context.SaveChanges();
