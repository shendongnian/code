        Using dbContext = new MyContext()
            Dim bewegung = dbContext.MyTable.Attach(New MyTable())
            bewegung.Entity.myKey = someKey
            bewegung.Entity.myOtherField = "1"
            dbContext.Entry(bewegung.Entity).State = EntityState.Modified
            dbContext.Update(bewegung.Entity)
            Dim BewegungenDescription = (From tp In dbContext.Model.GetEntityTypes() Where tp.ClrType.Name = "MyTable" Select tp).First()
            For Each p In (From prop In BewegungenDescription.GetProperties() Select prop)
                Dim pp = dbContext.Entry(bewegung.Entity).Property(p.Name)
                pp.IsModified = False
            Next
            dbContext.Entry(bewegung.Entity).Property(Function(row) row.myOtherField).IsModified = True
            dbContext.SaveChanges()
        End Using
