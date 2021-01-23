    var res = from f in db.MasterTables
              where f.MasterColun1 == "wtf"
              select new 
              {
                 f.Id,
                 Cols1 = f.Slave1s.Select(s => s.SlaveCol1).ToArray()
                 Cols2 = f.Slave2s.Select(s => s.SlaveColumn2).ToArray()
              }
