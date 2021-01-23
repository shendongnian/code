     select new World
              {
               ID = g.Key.SpaceTypeID,
               Code = g.Key.SpaceTypeCode,
              Count = g.Count()
               })
