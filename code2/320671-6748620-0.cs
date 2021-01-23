     IQueryable<BusinessObject> filteredBoList = boList.AsQueryable();
     Type boType= typeof(BusinessObject);
     foreach(string filter in filterColumnNames) {
        var found = filteredBoList.Where(p =>    (string)boType.InvokeMember(filter.FieldName,BindingFlags.GetProperty, null, p, null) == filter ).Distinct();
     }
