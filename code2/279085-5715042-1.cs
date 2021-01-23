    var parent = GetUpdatedParentSomehow();
    // Dummy object for the old child if the relation is not loaded
    parent.Child = new Child { Id = oldChildId }; 
    // Attach the parent
    context.Parents.Attach(parent);
    // Create dummy for new child (you can also load a child from DB)
    var child = new Child { ID = newChildId };
    // No attach the child to the context so the context
    // doesn't track it as a new child
    context.Childs.Attach(child);
    // Set a new child
    parent.Child = child;
    // Set parent as modified
    context.Entry(parent).State = EntityState.Modified;
    context.SaveChanges();
    
