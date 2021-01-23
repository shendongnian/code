    var prop = emp.GetType().GetProperties();     //emp is my class
        foreach (var props in prop)
          {
            var variable = props.GetMethod;
                                                                     
            empHolder.Add(variable.Invoke(emp, null).ToString());  //empHolder = ArrayList
          }
