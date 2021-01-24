    var incidentImageModel = new IncidentImageModel();
    PropertyInfo[] properties = incidentImageModel.GetType().GetProperties();
    var result = from property in properties
                 let nameAndValue = new { property.Name, Value = (int)property.GetValue(incidentImageModel) }
                 where nameAndValue.Value == 1
                 select nameAndValue;
