    'In this mode you update the sixth row (only the column 20)
    Dim query As EnumerableRowCollection(Of Object) = From dRow As DataRow In Dt.AsEnumerable()
                                                      Select col20 = dRow.Item(20)
                                                      Skip 5
                                                      Take 1
    
    
    
    For Each Row As DataRow In query
        Row.Item(0) = "A"
    Next
    
    
    'In this mode you get all rows 
    Dim queryAllRowData As EnumerableRowCollection(Of DataRow) = From dRow As DataRow In Dt.AsEnumerable()
    
    
    
    
    For Each Row As DataRow In queryAllRowData
        Row.ItemArray = {"A", "A", "A", "A", "A", "A"}
    Next
    
    
    
    
    
    'Don't forget commit changes
    Dt.AcceptChanges()
