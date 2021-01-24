    Private Sub ChangeAllPivotSources()
        Dim objSlicerCache As SlicerCache
        Dim objPivotTable As PivotTable
        Dim objPivotTables() As PivotTable
        Dim i As Long
            
        ' get the slicercache, e. g. via its first pivottable:
        Set objPivotTable = ActiveWorkbook.Sheets(1).PivotTables(1)
        Set objSlicerCache = objPivotTable.Slicers(1).SlicerCache
        
        ' dimension array with all pivottable objects of the slicercache
        ReDim objPivotTables(1 To objSlicerCache.PivotTables.Count)
        
        ' remove all pivottables from slicer's report connections
        For i = objSlicerCache.PivotTables.Count To 1 Step -1
            Set objPivotTables(i) = objSlicerCache.PivotTables(i)
            objSlicerCache.PivotTables.RemovePivotTable objPivotTables(i)
        Next i
        
        ' create new pivotcache based on a new range for the first pivottable,
        ' use this pivotcache for all other pivottables also
        For i = 1 To UBound(objPivotTables)
            If i = 1 Then
                objPivotTables(i).ChangePivotCache ActiveWorkbook.PivotCaches.Create( _
                    SourceType:=xlDatabase, _
                    SourceData:=ActiveWorkbook.Sheets(3).Range("A1").CurrentRegion)
            Else
                objPivotTables(i).ChangePivotCache objPivotTables(1).Name
            End If
        Next i
        
        ' reassign the report connections again
        For i = 1 To UBound(objPivotTables)
            objSlicerCache.PivotTables.AddPivotTable objPivotTables(i)
        Next i
        
    End Sub
