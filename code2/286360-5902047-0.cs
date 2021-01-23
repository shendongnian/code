      ChildMap() {
          CompositeId() //This is is good
            .KeyReference(x => x.Parent, "ParentId")
            .KeyReference(x => x.Other, "OtherId");
      }
    
      ParentMap(){ //This is the fix
            HasMany(c => c.Children)
              .Inverse()
              .Cascade.All()
              .KeyColumn("ParentId")
              .Table("[Test]");
      }
