    // ...
    var existingObject = context.Events.Include("RecurrenceRule")
        .FirstOrDefault(p => p.Ident == obj.Ident);
    context.ApplyCurrentValues<Event>(obj.EntityKey.EntitySetName, obj);
    if (obj.RecurrenceRule != null)
        context.ApplyCurrentValues<RecurrenceRule>(
            obj.RecurrenceRule.EntityKey.EntitySetName, obj.RecurrenceRule);
    // ...
