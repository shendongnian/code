    Public Function GetShapesThatConnectTo(TheShp As Visio.Shape) As Collection
        Dim Result As Collection
        Set Result = New Collection
        For i = 1 To TheShp.FromConnects.Count
            Result.Add TheShp.FromConnects.Item(i).FromSheet
        Next i
        Set GetShapesThatConnectTo = Result
    End Function
    
    Public Function GetWhatShapeConnectsTo(TheShp As Visio.Shape) As Collection
        Dim Result As Collection
        Set Result = New Collection
        For i = 1 To TheShp.Connects.Count
            Result.Add TheShp.Connects.Item(i).ToSheet
        Next i
        Set GetWhatShapeConnectsTo = Result
    End Function
