    Dim item As GroupSelect = collection.Where(Function(i) i.RowNo = RowNo AndAlso i.GroupNo = GroupNo).SingleOrDefault()
    
    If item Is Nothing Then
    	Dim newItem As New GroupSelect()
    	newItem.GroupNo = GroupNo
    	newItem.RowNo = RowNo
    
    	newItem.Value = Value
    
    	collection.Add(newItem)
    Else
    	item.Value = Value
    End If
