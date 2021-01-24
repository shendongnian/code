      using System.Linq;
      ...
      List<ModelClas> obj = Ids
        .Zip(names, (id, name) => new ModelClas() {
           Id = id, 
           Names = name
          })
        .ToList();
