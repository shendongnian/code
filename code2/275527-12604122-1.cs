    ''' <summary>
    ''' Compares the data between both datatables to check if they have the same content or not.
    ''' Columns and Rows do not need to be in the same order as the other, just that the data in any of them need to be the same.
    ''' </summary>
    ''' <param name="dtbl_a">The first datatable to compare.</param>
    ''' <param name="dtbl_b">The second datatable to compare.</param>
    ''' <param name="debug">For troubleshooting and checking the function is working correctly.  Typically this is 'false'.</param>
    ''' <returns>Boolean:  False if the data between the two datatables are different, True if the data between them are the same.</returns>
    ''' <remarks></remarks>
    Public Function dataTablesAreEqual _
                                      (ByRef dtbl_a As System.Data.DataTable, _
                                       ByRef dtbl_b As System.Data.DataTable, _
                                       ByVal debug As System.Boolean) As System.Boolean
        Dim recordCount(1) As System.Int32
        Dim columnCount(1) As System.Int32
        Dim length(1) As System.Int32
        Dim dtbl_check(1) As System.Data.DataTable
        Dim debugMessage As New System.Text.StringBuilder
        Dim errorMessage As System.String
        Dim result As System.Boolean
        Try
            If debug = True Then
                debugMessage.AppendLine("checking:  priliminary (and easy to see) tests being done...")
                debugMessage.AppendLine("checking:  what is nothing and what is not nothing.")
            End If
            If dtbl_a Is Nothing And dtbl_b Is Nothing Then
                result = True
                If debug = True Then
                    debugMessage.AppendLine("decision:  " & result.ToString & "!")
                    debugMessage.AppendLine("  reason:  dtbl_a Is Nothing And dtbl_b Is Nothing.")
                End If
                Return result
            ElseIf dtbl_a Is Nothing And dtbl_b IsNot Nothing Then
                result = False
                If debug = True Then
                    debugMessage.AppendLine("decision:  " & result.ToString & "!")
                    debugMessage.AppendLine("  reason:  dtbl_a Is Nothing And dtbl_b IsNot Nothing.")
                End If
                Return result
            ElseIf dtbl_a IsNot Nothing And dtbl_b Is Nothing Then
                result = False
                If debug = True Then
                    debugMessage.AppendLine("decision:  " & result.ToString & "!")
                    debugMessage.AppendLine("  reason:  dtbl_a IsNot Nothing And dtbl_b Is Nothing.")
                End If
                Return result
            End If
            If debug = True Then
                debugMessage.AppendLine("checking:  differences in row and column counts.")
            End If
            recordCount(0) = dtbl_a.Rows.Count
            columnCount(0) = dtbl_a.Columns.Count
            recordCount(1) = dtbl_b.Rows.Count
            columnCount(1) = dtbl_b.Columns.Count
            If recordCount(0) <> recordCount(1) Then
                result = False
                If debug = True Then
                    debugMessage.AppendLine("decision:  " & result.ToString & "!")
                    debugMessage.AppendLine("  reason:  the # of rows are different.")
                    debugMessage.AppendLine("  reason:  dtbl_a has " & recordCount(0) & " record(s) and dtbl_b has " & recordCount(1) & " record(s).")
                End If
                Return result
            ElseIf columnCount(0) <> columnCount(1) Then
                result = False
                If debug = True Then
                    debugMessage.AppendLine("decision:  " & result.ToString & "!")
                    debugMessage.AppendLine("  reason:  the # of columns are different.")
                    debugMessage.AppendLine("  reason:  dtbl_a has " & columnCount(0) & " column(s) and dtbl_b has " & columnCount(1) & " column(s).")
                End If
                Return result
            End If
            Dim lowerBound_Records As System.Int32
            Dim upperBound_Records As System.Int32
            Dim current_Record As System.Int32
            Dim lowerBound_Columns As System.Int32
            Dim upperBound_Columns As System.Int32
            Dim current_Column As System.Int32
            lowerBound_Records = 0
            upperBound_Records = (recordCount(0) - 1)
            lowerBound_Columns = 0
            upperBound_Columns = (columnCount(0) - 1)
            If debug = True Then
                debugMessage.AppendLine("checking:  columns exist in both tables (can be in different order).")
            End If
            For current_Column = lowerBound_Columns To upperBound_Columns
                Dim columnName As System.String
                Dim exists As System.Boolean
                columnName = dtbl_a.Columns(current_Column).ColumnName
                exists = dtbl_b.Columns.Contains(columnName)
                If exists = False Then
                    result = False
                    If debug = True Then
                        debugMessage.AppendLine("decision:  " & result.ToString & "!")
                        debugMessage.AppendLine("  reason:  the column [" & columnName & "] in dtbl_a does NOT EXIST in dtbl_b.")
                    End If
                    Return result
                End If
            Next current_Column
            dtbl_check(0) = New System.Data.DataTable
            dtbl_check(0).Columns.Add("index", GetType(System.Int32))
            dtbl_check(0).Columns.Add("hashCode", GetType(System.Int32))
            dtbl_check(0).Columns.Add("checked", GetType(System.DateTime))
            If debug = True Then
                dtbl_check(0).Columns.Add("dataRow", GetType(System.String))
            End If
            dtbl_check(0).PrimaryKey = New System.Data.DataColumn() {dtbl_check(0).Columns("index"), dtbl_check(0).Columns("hashCode")}
            dtbl_check(1) = dtbl_check(0).Copy
            If debug = True Then
                debugMessage.AppendLine("checking:  going for the extensive data content check (rows can be in different order).")
                debugMessage.AppendLine("checking:  getting hashcodes from dtbl_a started:  " & System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.ffff"))
            End If
            For current_Record = lowerBound_Records To upperBound_Records
                Dim dataRow_check As New System.Text.StringBuilder
                dataRow_check.Append("<dataRow>")
                For current_Column = lowerBound_Columns To upperBound_Columns
                    Dim columnName As System.String
                    Dim valueIsNull As System.Boolean
                    Dim value As System.String
                    columnName = dtbl_a.Columns(current_Column).ColumnName
                    valueIsNull = System.Convert.IsDBNull(dtbl_a.Rows(current_Record).Item(columnName))
                    If valueIsNull = False Then
                        value = dtbl_a.Rows(current_Record).Item(columnName).ToString
                    Else
                        value = "[null]"
                    End If
                    dataRow_check.Append("<" & columnName & ">" & value & "</" & columnName & ">")
                Next current_Column
                dataRow_check.Append("</dataRow>")
                Dim newRow As System.Data.DataRow = dtbl_check(0).NewRow
                Call newRow.BeginEdit()
                newRow.Item("index") = current_Record
                newRow.Item("hashCode") = dataRow_check.ToString.GetHashCode
                newRow.Item("checked") = System.Convert.DBNull
                If debug = True Then
                    newRow.Item("dataRow") = dataRow_check.ToString
                End If
                Call newRow.EndEdit()
                Call dtbl_check(0).Rows.Add(newRow)
                dataRow_check = Nothing
            Next current_Record
            If debug = True Then
                debugMessage.AppendLine("checking:  finished hashcodes for dtbl_a ended:  " & System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.ffff"))
                debugMessage.AppendLine("checking:  getting hashcodes from dtbl_b and cross checking using dtbl_a started:  " & System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.ffff"))
                 
            End If
            For current_Record = lowerBound_Records To upperBound_Records
                Dim dataRow_check As New System.Text.StringBuilder
                Dim checked As System.DateTime
                checked = System.DateTime.Now
                dataRow_check.Append("<dataRow>")
                For current_Column = lowerBound_Columns To upperBound_Columns
                    Dim columnName As System.String
                    Dim valueIsNull As System.Boolean
                    Dim value As System.String
                    columnName = dtbl_a.Columns(current_Column).ColumnName
                    Try
                        valueIsNull = System.Convert.IsDBNull(dtbl_b.Rows(current_Record).Item(columnName))
                    Catch exc As System.Exception
                        result = False
                        Return result
                    End Try
                    If valueIsNull = False Then
                        value = dtbl_b.Rows(current_Record).Item(columnName).ToString
                    Else
                        value = "[null]"
                    End If
                    dataRow_check.Append("<" & columnName & ">" & value & "</" & columnName & ">")
                Next current_Column
                dataRow_check.Append("</dataRow>")
                Dim selectQuery As System.String
                Dim dataRows() As System.Data.DataRow
                Dim hashCode As System.Int32
                hashCode = dataRow_check.ToString.GetHashCode
                selectQuery = "[hashCode] = " & hashCode.ToString & " and [checked] is null "
                dataRows = dtbl_check(0).Select(selectQuery)
                If dataRows.Length > 0 Then
                    Call dataRows(0).BeginEdit()
                    dataRows(0).Item("checked") = checked
                    Call dataRows(0).EndEdit()
                    Dim newRow As System.Data.DataRow = dtbl_check(1).NewRow
                    Call newRow.BeginEdit()
                    newRow.Item("index") = dataRows(0).Item("index")
                    newRow.Item("hashCode") = dataRows(0).Item("hashCode")
                    newRow.Item("checked") = checked
                    If debug = True Then
                        newRow.Item("dataRow") = dataRow_check.ToString
                    End If
                    Call newRow.EndEdit()
                    Call dtbl_check(1).Rows.Add(newRow)
                Else
                    result = False
                    If debug = True Then
                        debugMessage.AppendLine("checking:  finished hashcodes for dtbl_b ended:  " & System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.ffff"))
                        debugMessage.AppendLine("decision:  " & result.ToString & "!")
                        debugMessage.AppendLine("  reason:  a row in dtbl_b doesn't match up in dtbl_a (either due to changes or didn't exist).")
                        debugMessage.AppendLine(" dataRow:  " & dataRow_check.ToString)
                    End If
                    dataRow_check = Nothing
                    Return result
                End If
                dataRows = Nothing
                dataRow_check = Nothing
            Next current_Record
            result = True
            If debug = True Then
                debugMessage.AppendLine("checking:  finished hashcodes for dtbl_b ended:  " & System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.ffff"))
                debugMessage.AppendLine("decision:  " & result.ToString & "!")
                debugMessage.AppendLine("  reason:  all " & recordCount(0) & " record(s) match up between both tables.")
            End If
        Catch exc_Exception As System.Exception
            errorMessage = exc_Exception.Message
            result = False
            If debug = True Then
                debugMessage.AppendLine("exception in dataTablesAreEqual!")
                debugMessage.AppendLine("decision:  " & result.ToString & "!")
                debugMessage.AppendLine(" message:  " & errorMessage)
            End If
        Finally
            If dtbl_check(1) IsNot Nothing Then
                Call dtbl_check(1).Clear()
                dtbl_check(1) = Nothing
            End If
            If dtbl_check(0) IsNot Nothing Then
                Call dtbl_check(0).Clear()
                dtbl_check(0) = Nothing
            End If
            If debug = True Then
                Call System.Diagnostics.Debug.WriteLine(debugMessage.ToString)
            End If
            debugMessage = Nothing
        End Try
        Return result
    End Function
