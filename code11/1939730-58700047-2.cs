      List<ModelClas> obj = new List<ModelClas>();
      // Math.Min - to be on the safe side if the arrays are of different lengths 
      for (int i = 0; i < Math.Min(Ids.Length, names.Length); ++i) {
        // i-th Ids and names into ModelClas   
        obj.Add(new ModelClas() {
          Id = Ids[i],
          Names = names[i] 
        }); 
      } 
