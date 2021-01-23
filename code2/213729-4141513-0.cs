    var map = new Dictionary<string, string>
                  {
                    { criteria.EmpName, emp.EmpName },       
                    { criteria.OfficeName, emp.OfficeName},
                    { criteria.ThirdProp, emp.ThirdProp }
                  };
    
    bIsMatch = dict.All(kvp => string.IsNullOrEmpty(kvp.Key) || kvp.Key == kvp.Value);
