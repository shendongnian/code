var return= db.Set<DataBaseObject>(CollectionName)
              .Aggregate()
              .Match(doc => doc.Id.Equals(id))
              .Group(doc => doc.Id, g => new
              {
                  Id = g.Key,
                  nestedArray = g.Select(x => new 
                  {
                      x.name,
                      x.cars
                  })
              })
              .Project(model => new ProjectObject
              {
                  externalId = model.Id,
                  nestedArray = (List<NestedArrayObject>) model.nestedArray.Select(pv => new
                 {
                      pv.name,
                      cars = pv.cars.Where(a=>a.new\)
                  })
              }).FirstOrDefault();
