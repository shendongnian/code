    public JArray GetEmployeeInfo(string search_text)
    {
        var search = search_text.Split(' ');
        var dataObject = _db.Employee
            .Where(x => x.Usage.Equals("basic") && 
                        search.All(s => x.EmployeeName.Contains(s) || 
                                        x.EmployeeEmailAddress.Contains(s) || 
                                        x.EmployeeId.Contains(s)))
            .Select(x => new
            {
                x.EmployeeId,
                x.EmployeeName,
                x.EmployeeEmailAddress,
                x.EmployeeDepartmentName,
                x.UsageTags
            })
            .ToList();    // materialize the database query
        var array = new JArray(
            dataObject.Select(o =>
            {
                var jo = JObject.FromObject(o);
                // parse and transform the UsageTags
                jo["UsageTags"] = new JArray(
                    JArray.Parse((string)jo["UsageTags"])
                          .Select(jt => jt["Tag"])
                );
                return jo;
            })
        );
        return array;
    }
