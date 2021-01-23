     Public Function UpdateEntity(entity As Entity) As Entity
        Using dbContext As New EntityContext()
            dbContext.EntitySet.ApplyChanges(entity)
            dbContext.SaveChanges()
            dbContext.Refresh(Objects.RefreshMode.StoreWins, entity)
        End Using
        Return entity 
    End Function
