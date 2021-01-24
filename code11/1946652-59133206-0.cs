     var common = original.Where(x => revised.Exists(z => z.ID == x.ID)).ToList();
     var nonCommon = revised.Where(x => !original.Exists(z => z.ID == x.ID)).ToList();
     foreach(var item in common)
     {
          var derived = revised.FirstOrDefault(x => x.ID == item.ID);
          // Added Extention Method to compare and update property
          var data = item.UpdateProperties(derived);
     }
     common.AddRange(nonCommon);
