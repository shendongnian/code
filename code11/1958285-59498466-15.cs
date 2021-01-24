      foreach (var tuple in fieldsWithTuples.Select(f => f.value)) {
        var result = tuple
          .GetType()
          .GetProperties()
          .Where(prop => prop.CanRead)
          .Where(prop => !prop.GetIndexParameters().Any())
          .Where(prop => Regex.IsMatch(prop.Name, "^Item[0-9]+$"))
          .Select(prop => new {
             name  = prop.Name,
             value = prop.GetValue(tuple), 
           });
        foreach (var item in result)
          Debug.WriteLine($"{item.name} = {item.value}");
      }
