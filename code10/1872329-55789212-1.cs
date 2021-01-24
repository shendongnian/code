      // instead of new add the call to get the Ienumerable
      IEnumerable<VehicleFactoryOptionModel> optionModels = new List<VehicleFactoryOptionModel>();
      // fill type name and id for the technical
      var result = optionModels.Select(x => new {x.TypeId, x.TypeName, x.Data}).
          Where(x => x.TypeName.ToString() == "Technical").ToList();
    
      // select only the data list for mechanical
      var test = optionModels.
          Where(x=>x.TypeName.ToString() == "Mechanical").SelectMany(x=>x.Data );
    
      // add it to the technical list,
      // assumption that there will be only one list for the techincal..thats why the index 0
      result[0].Data.AddRange(test);
