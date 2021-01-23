    var Results =
        from a in Db.Table1
          join b in Db.Table2 on 
                   new { ID= a.Id, Bit = true } 
                   equals 
                   new { ID = b.Id, Bit = b.Value ==1 } 
          into c 
          from d in c.DefaultIfEmpty()
          select new {
               Table1 = a, 
               Table2= d  //will be null if b.Value is not 1
          };
