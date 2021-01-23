    var propertyInfo = item.GetType().GetProperty(_identityProp);
    var value = propertyInfo.GetValue(item, null);
    var items = _db.All<T>()
                   .Where(i => propertyInfo.GetValue(i, null) == val)
                   .ToList();
