    var properties = typeof(Employee).GetProperties()
                                     .Where(p => p.PropertyType == typeof(string));
    foreach(var employee in employees) {
        foreach(var property in properties) {
             string value = (string)property.GetValue(employee, null);
             if(String.IsNullOrWhiteSpace(value)) {
                 yield return employee;
                 break;
             }
        }
    }
