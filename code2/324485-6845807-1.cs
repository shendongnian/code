    Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)
       If TypeOf obj Is StyledItem Then
             Dim si As StyledItem = CType(obj, StyledItem)
             Items.Add(si)
       Else
             Throw New ArgumentException ("A StyledList server control may contain only StyledItems")
       End If
    End Sub
