    var differences = Existing.Keys.Intersect(New.Keys).SelectMany(key =>
        from existingObj in Existing[key]
        join newObj in New[key] on new { existingObj.Name, existingObj.Type } equals
                                   new { newObj.Name, newObj.Type }
        where existingObj.Value != newObj.Value
        select new { Key = key, Existing = existingObj, New = newObj });
