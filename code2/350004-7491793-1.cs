    // ...
    var existingObject = context.Events.Include("RecurrenceRule")
        .FirstOrDefault(p => p.Ident == obj.Ident);
    context.ApplyCurrentValues<Event>(obj.EntityKey.EntitySetName, obj);
    // 1st case: Relationship to RecurrenceRule has been removed or didn't exist
    if (obj.RecurrenceRule == null)
        existingObject.RecurrenceRule = null;
    // 2nd case: Relationship to RecurrenceRule must be set or updated
    else
    {
         // relationship has changed
        if (existingObject.RecurrenceRule == null ||
            obj.RecurrenceRule.Id != existingObject.RecurrenceRule.Id)
        {
            var existingRecurrenceRule = context.RecurrenceRule
                .SingleOrDefault(r => r.Id == obj.RecurrenceRule.Id);
            if (existingRecurrenceRule != null) // RecurrenceRule exists in DB
            {
                // Update scalar values
                context.ApplyCurrentValues<RecurrenceRule>(
                   obj.RecurrenceRule.EntityKey.EntitySetName, obj.RecurrenceRule);
            }
            else // RecurrenceRule does not exist in DB
            {
                // nothing to do, SaveChanges will recognize new RecurrenceRule
                // and create INSERT statement
            }
            // set new relationship
            existingObject.RecurrenceRule = obj.RecurrenceRule;
        }
        else // same relationship: just update scalar values
        {
            // Update scalar values
            context.ApplyCurrentValues<RecurrenceRule>(
                obj.RecurrenceRule.EntityKey.EntitySetName, obj.RecurrenceRule);
        }
    }
    // ...
