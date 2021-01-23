    var res = from f in db.MasterTables
              where f.MasterColumn1 == "wtf"
              let s1 = f.Slave1s.Select(s => s.SlaveCol1)
              let s2 = f.Slave2s.Select(s => s.SlaveColumn2)
              select new {
                             f.Id, 
                             SlaveCols1 = s1,
                             SlaveCols2 = s2
                         };
