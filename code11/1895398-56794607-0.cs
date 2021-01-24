    foreach (var result in response.results) {
      var parameters = new DynamicParameters();
    
      foreach (PropertyInfo prop in result.GetType().GetProperties()) {
          
          if (!SpecialParameter(result, prop, parameters))
             parameters.Add(prop.Name, prop.GetValue(result, null));
      }
    
      db.Execute("save_data",
             parameters, commandType: CommandType.StoredProcedure);
    }    
    function SpecialParameter(result, prop, parameters) {
    // can be implemented in the sub class
       switch (prop.Name) {
          case "location":
             parameters.Add("location_city", result.city);
             parameters.Add("location_state", result.city);
             return true;
       }
      return false;
    }
