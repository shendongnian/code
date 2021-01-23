    Sub test()
    Dim strFieldName As String
    Dim rngHeading As Range
    With Sheet1
    
        strFieldName = "Heading 3" 'find Heading Name
        With .Rows("1:1") 'search row 1 headings
    
            Set rngHeading = .Find(What:=strFieldName, LookIn:=xlValues, lookAt:=xlWhole, _
            SearchOrder:=xlByColumns, SearchDirection:=xlNext, _
            MatchCase:=False, SearchFormat:=False)
        
            'check if found
            If Not rngHeading Is Nothing Then
        
            MsgBox rngHeading.Address
            MsgBox rngHeading.Row
            MsgBox rngHeading.Column
            rngHeading.EntireColumn.NumberFormat = "m/d/yyyy"
               
            End If
    
        End With
    End With
    End Sub
