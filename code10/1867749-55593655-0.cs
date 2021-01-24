    public async Task<IEnumerable<Manager>> GetManagerWithFacilitiesByManagerName(string name)
    {
        var managersDictionary = new Dictionary<int, Manager>();
        
        await connection.Query<Manager, Facility, Manager>(
           @"SELECT * 
             FROM Manager AS m 
             INNER JOIN Facilities as f ON f.ManagerId = m.ManagerId
             WHERE m.Name = @name", 
           (manager, facility) => 
           { 
               Manager managerEntity;
        
               if (managersDictionary.ContainsKey(m.ManagerId)
               {
                   managerEntity = managersDictionary[manager.ManagerId];
               } 
               else 
               {
                   managerEntity = manager;
                   managerEntity.Facilities = new List<Facilities>();
                   managersDictionary.Add(managerEntity.ManagerId, managerEntity);
               }
        
               managerEntity.Facilities.Add(facility);
        
               return managerEntity;
           }
           new {name = name},
           splitOn: "ManagerId,FacilityId") // properties where to split entity
        
        return managersDictionary.Values;    
    } 
