    Protected Sub UpdateManyToMany(Of T As Class)(database as SomeEntities, collection As ICollection(Of T), idList As List(Of Integer))
    'update a many to many collection given a list of key IDs
      collection.Clear()
      Dim source = database.Set(Of T)()
      If idList IsNot Nothing Then
        For Each i As Integer In idList
          Dim record = source.Find(i)
          collection.Add(record)
        Next
      End If
    End Sub
