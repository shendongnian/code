        (from blueprint in blueprints
         from material in blueprint.Input.Keys
         where itemsDictionary.ContainsKey(material.Id)
         select new { material, name = itemsDictionary[material.Id] })
         .ToList()
         .ForEach(rs => rs.material.Name = rs.name);
        (from blueprint in blueprints
         where itemsDictionary.ContainsKey(blueprint.Output.Id)
         select new { blueprint, name = itemsDictionary[blueprint.Output.Id] })
         .ToList()
         .ForEach(rs => rs.blueprint.Output.Name = rs.name);
